namespace Client.Model.Base
{
    public interface IEntityBase<TId>
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public TId Id { get; set; }
        public bool Enabled { get; set; }
        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Дата обновления сущности
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
