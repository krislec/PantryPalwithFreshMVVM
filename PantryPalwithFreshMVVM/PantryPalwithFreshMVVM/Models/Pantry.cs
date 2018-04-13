using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace PantryPalwithFreshMVVM.Models
{

    [Table("Pantry")]
    public class Pantry

    {
        //represents the data stored in the table
        //PrimaryKey - tells SQLite that this colomn is going to be the primary key of the table-needs to be unique and an index is applied to speed up retrievals
        //AutoIncrement - when new "item" is inserted into table the ID column will populate automatically  

        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        //unique ID that is used to refer to specific "item"

        [Column("Pantry Item")]
        [NotNull, MaxLength(100)]
        public string NameOfItem { get; set; }
        [Column("Quantity")]
        public string Quantity { get; set; }
        [Column("Measurement")]
        public string Measurement { get; set; }
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(NameOfItem);
        }


        private string _quantityMeasurement;
      public string QuantityMeasurement
        {
            get
            {
                return Quantity + " " + Measurement;
            }

            set
            {
                _quantityMeasurement = value;
            }
        }
        
      

       
    }
}
