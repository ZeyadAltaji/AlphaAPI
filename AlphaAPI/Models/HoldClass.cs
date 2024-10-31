using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaAPI.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class InventoryHold
    {

        private string serialKeyField;

        private string transmitLogKeyField;

        private string addDateField;

        private InventoryHoldInventoryHoldHeader inventoryHoldHeaderField;

        private string[] textField;

        /// <remarks/>
        public string SerialKey
        {
            get
            {
                return this.serialKeyField;
            }
            set
            {
                this.serialKeyField = value;
            }
        }

        /// <remarks/>
        public string TransmitLogKey
        {
            get
            {
                return this.transmitLogKeyField;
            }
            set
            {
                this.transmitLogKeyField = value;
            }
        }

        /// <remarks/>
        public string AddDate
        {
            get
            {
                return this.addDateField;
            }
            set
            {
                this.addDateField = value;
            }
        }

        /// <remarks/>
        public InventoryHoldInventoryHoldHeader InventoryHoldHeader
        {
            get
            {
                return this.inventoryHoldHeaderField;
            }
            set
            {
                this.inventoryHoldHeaderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InventoryHoldInventoryHoldHeader
    {

        private string originField;

        private string holdTrnGroupField;

        private string storerKeyField;

        private string sKUField;

        private string lotField;

        private string locField;

        private string holdTRNAddDateField;

        private string countSequenceField;

        private string commentsField;

        private string prodStageLocField;

        private string ext_udf_str1Field;

        private InventoryHoldInventoryHoldHeaderSkuInfo skuInfoField;

        private InventoryHoldInventoryHoldHeaderCommodity commodityField;

        private InventoryHoldInventoryHoldHeaderLotAttribute lotAttributeField;

        private InventoryHoldInventoryHoldHeaderFacility facilityField;

        private InventoryHoldInventoryHoldHeaderStorerAccountingEntity storerAccountingEntityField;

        private InventoryHoldInventoryHoldHeaderInventoryHoldDetail[] inventoryHoldDetailField;

        private string[] textField;

        /// <remarks/>
        public string Origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
            }
        }

        /// <remarks/>
        public string HoldTrnGroup
        {
            get
            {
                return this.holdTrnGroupField;
            }
            set
            {
                this.holdTrnGroupField = value;
            }
        }

        /// <remarks/>
        public string StorerKey
        {
            get
            {
                return this.storerKeyField;
            }
            set
            {
                this.storerKeyField = value;
            }
        }

        /// <remarks/>
        public string SKU
        {
            get
            {
                return this.sKUField;
            }
            set
            {
                this.sKUField = value;
            }
        }

        /// <remarks/>
        public string Lot
        {
            get
            {
                return this.lotField;
            }
            set
            {
                this.lotField = value;
            }
        }

        /// <remarks/>
        public string Loc
        {
            get
            {
                return this.locField;
            }
            set
            {
                this.locField = value;
            }
        }

        /// <remarks/>
        public string HoldTRNAddDate
        {
            get
            {
                return this.holdTRNAddDateField;
            }
            set
            {
                this.holdTRNAddDateField = value;
            }
        }

        /// <remarks/>
        public string CountSequence
        {
            get
            {
                return this.countSequenceField;
            }
            set
            {
                this.countSequenceField = value;
            }
        }

        /// <remarks/>
        public string Comments
        {
            get
            {
                return this.commentsField;
            }
            set
            {
                this.commentsField = value;
            }
        }

        /// <remarks/>
        public string ProdStageLoc
        {
            get
            {
                return this.prodStageLocField;
            }
            set
            {
                this.prodStageLocField = value;
            }
        }

        /// <remarks/>
        public string ext_udf_str1
        {
            get
            {
                return this.ext_udf_str1Field;
            }
            set
            {
                this.ext_udf_str1Field = value;
            }
        }

        /// <remarks/>
        public InventoryHoldInventoryHoldHeaderSkuInfo SkuInfo
        {
            get
            {
                return this.skuInfoField;
            }
            set
            {
                this.skuInfoField = value;
            }
        }

        /// <remarks/>
        public InventoryHoldInventoryHoldHeaderCommodity Commodity
        {
            get
            {
                return this.commodityField;
            }
            set
            {
                this.commodityField = value;
            }
        }

        /// <remarks/>
        public InventoryHoldInventoryHoldHeaderLotAttribute LotAttribute
        {
            get
            {
                return this.lotAttributeField;
            }
            set
            {
                this.lotAttributeField = value;
            }
        }

        /// <remarks/>
        public InventoryHoldInventoryHoldHeaderFacility Facility
        {
            get
            {
                return this.facilityField;
            }
            set
            {
                this.facilityField = value;
            }
        }

        /// <remarks/>
        public InventoryHoldInventoryHoldHeaderStorerAccountingEntity StorerAccountingEntity
        {
            get
            {
                return this.storerAccountingEntityField;
            }
            set
            {
                this.storerAccountingEntityField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("InventoryHoldDetail")]
        /// <remarks/>
        public InventoryHoldInventoryHoldHeaderInventoryHoldDetail[] InventoryHoldDetail
        {
            get
            {
                return this.inventoryHoldDetailField;
            }
            set
            {
                this.inventoryHoldDetailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InventoryHoldInventoryHoldHeaderSkuInfo
    {

        private string aLTSKUField;

        private string pACKUOM3Field;

        private string[] textField;

        /// <remarks/>
        public string ALTSKU
        {
            get
            {
                return this.aLTSKUField;
            }
            set
            {
                this.aLTSKUField = value;
            }
        }

        /// <remarks/>
        public string PACKUOM3
        {
            get
            {
                return this.pACKUOM3Field;
            }
            set
            {
                this.pACKUOM3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InventoryHoldInventoryHoldHeaderCommodity
    {

        private string storerKeyField;

        private string skuField;

        private string nonStockedIndicatorField;

        private string accountingEntityField;

        private string[] textField;

        /// <remarks/>
        public string StorerKey
        {
            get
            {
                return this.storerKeyField;
            }
            set
            {
                this.storerKeyField = value;
            }
        }

        /// <remarks/>
        public string Sku
        {
            get
            {
                return this.skuField;
            }
            set
            {
                this.skuField = value;
            }
        }

        /// <remarks/>
        public string NonStockedIndicator
        {
            get
            {
                return this.nonStockedIndicatorField;
            }
            set
            {
                this.nonStockedIndicatorField = value;
            }
        }

        /// <remarks/>
        public string AccountingEntity
        {
            get
            {
                return this.accountingEntityField;
            }
            set
            {
                this.accountingEntityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InventoryHoldInventoryHoldHeaderLotAttribute
    {

        private string lottable03Field;

        private string lottable04Field;

        private string lottable05Field;

        private string[] textField;

        /// <remarks/>
        public string Lottable03
        {
            get
            {
                return this.lottable03Field;
            }
            set
            {
                this.lottable03Field = value;
            }
        }

        /// <remarks/>
        public string Lottable04
        {
            get
            {
                return this.lottable04Field;
            }
            set
            {
                this.lottable04Field = value;
            }
        }

        /// <remarks/>
        public string Lottable05
        {
            get
            {
                return this.lottable05Field;
            }
            set
            {
                this.lottable05Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InventoryHoldInventoryHoldHeaderFacility
    {

        private string storerKeyField;

        private string accountingEntityField;

        private string[] textField;

        /// <remarks/>
        public string StorerKey
        {
            get
            {
                return this.storerKeyField;
            }
            set
            {
                this.storerKeyField = value;
            }
        }

        /// <remarks/>
        public string AccountingEntity
        {
            get
            {
                return this.accountingEntityField;
            }
            set
            {
                this.accountingEntityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InventoryHoldInventoryHoldHeaderStorerAccountingEntity
    {

        private string accountingEntityField;

        private string[] textField;

        /// <remarks/>
        public string AccountingEntity
        {
            get
            {
                return this.accountingEntityField;
            }
            set
            {
                this.accountingEntityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InventoryHoldInventoryHoldHeaderInventoryHoldDetail
    {

        private string originField;

        private string holdCodeField;

        private decimal qtyField;

        private string[] textField;

        /// <remarks/>
        public string Origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
            }
        }

        /// <remarks/>
        public string HoldCode
        {
            get
            {
                return this.holdCodeField;
            }
            set
            {
                this.holdCodeField = value;
            }
        }

        /// <remarks/>
        public decimal Qty
        {
            get
            {
                return this.qtyField;
            }
            set
            {
                this.qtyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }


}
