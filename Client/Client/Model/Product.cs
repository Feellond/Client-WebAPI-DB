using Client.Model.Base;
using Client.Model.Const;

namespace Client.Model
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Форма продукта
        /// </summary>
        public int Shape { get; set; } = (int)ShapeEnum.None;
        /// <summary>
        /// Стандартная доза
        /// </summary>
        public string Dosage { get; set; } = string.Empty;
        /// <summary>
        /// Дата выпуска
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// Срок годности до
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }

    public class ProductRequest : Product
    {

    }
}
