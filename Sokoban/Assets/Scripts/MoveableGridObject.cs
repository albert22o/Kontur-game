using System;
using System.Collections;
using UnityEngine;

public abstract class MoveableGridObject : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected LayerMask blockingLayer;

    public event Action OnMoveStart;
    public event Action OnMoveEnd;
    public event Action OnCantMove;

    public bool IsMoving { get; private set; }

    /// <summary>
    /// Метод для попытки движения в заданном направлении
    /// </summary>
    /// <param name="direction">Направление движения</param>
    /// <returns>Возвращает произошло движение или нет</returns>
    public virtual bool Move(Vector3 direction)
    {
        if (IsMoving)
            return false;

        if (IsBlocked(direction, out RaycastHit hit))
        {
            if (!HandleCollision(hit, direction))
            {
                OnCantMove?.Invoke();
                return false;
            }
        }

        StartCoroutine(MoveRoutine(direction));
        return true;
    }

    /// <summary>
    /// Проверяет, заблокировано ли движение в заданном направлении
    /// </summary>
    /// <param name="direction">Направление движения</param>
    /// <param name="hit"></param>
    /// <returns></returns>
    protected virtual bool IsBlocked(Vector3 direction, out RaycastHit hit)
    {
        return Physics.Raycast(transform.position, direction, out hit, 1f, blockingLayer);
    }

    /// <summary>
    /// Метод для обработки столкновения с препятствием
    /// </summary>
    /// <param name="hit">Информация о препятствии</param>
    /// <param name="direction">Направление движения</param>
    /// <returns>Разрешено ли движение в препятствие</returns>
    protected virtual bool HandleCollision(RaycastHit hit, Vector3 direction)
    {
        return false; 
    }

    /// <summary>
    /// Подпроцесс передвижения объекта на один юнит в заданном направлении
    /// </summary>
    /// <param name="direction">Направление движения</param>
    /// <returns></returns>
    private IEnumerator MoveRoutine(Vector3 direction)
    {
        IsMoving = true;
        OnMoveStart?.Invoke();

        var startPos = transform.position;
        var targetPos = startPos + direction;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPos, targetPos, percent);
            yield return null;
        }

        transform.position = targetPos;
        IsMoving = false;
        OnMoveEnd?.Invoke();
    }
}