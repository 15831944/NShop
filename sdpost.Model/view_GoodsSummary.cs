using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;
namespace NShop.Model
{
    [Entity("view_GoodsSummary", "")]
    public class view_GoodsSummary : EntityBase
    {
        /// <summary>
        /// aCategory
        /// </summary>		
        [DataField("aCategory", "int")]
        public int aCategory { get; set; }

        /// <summary>
        /// aTotal
        /// </summary>		
        [DataField("aTotal", "int")]
        public int aTotal { get; set; }

        /// <summary>
        /// aPrice
        /// </summary>		
        [DataField("aPrice", "float")]
        public float aPrice { get; set; }

    }
}