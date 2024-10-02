﻿using WebAPI.DAL.Const;
using WebAPI.DAL.Entities.Base;

namespace WebAPI.DAL.Entities.Database
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
}
