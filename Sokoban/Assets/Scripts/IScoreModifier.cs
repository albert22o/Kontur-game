public interface IScoreModifier
{
    /// <summary>
    /// Изменяет значение очков
    /// </summary>
    /// <param name="oldScore">Старое значение очков</param>
    /// <returns>Возвращает новое значение очков</returns>
    public int ModifyScore(int oldScore);

    /// <summary>
    /// Отменяет изменение значения очков
    /// </summary>
    /// <param name="oldScore">Старое значение очков</param>
    /// <returns>Измененное значение очков</returns>
    public int RevertScore(int oldScore);
}