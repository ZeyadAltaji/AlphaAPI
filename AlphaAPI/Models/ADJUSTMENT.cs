using System;

namespace AlphaAPI.Models
{
    public class ADJUSTMENTCLS
    {
   
       
        public string transmitlogkey { get; set; }
        public DateTime adddate { get; set; }
        public string addwho { get; set; }
        public string billingtransmitflag { get; set; }
        public DateTime editdate { get; set; }
        public string editwho { get; set; }
        public string eventcategory { get; set; }
        public int eventfailurecount { get; set; }
        public int eventstatus { get; set; }
        public string key1 { get; set; }
        public string key2 { get; set; }
        public string key3 { get; set; }
        public string key4 { get; set; }
        public string key5 { get; set; }
        public string labortransmitflag { get; set; }
        public string message { get; set; }
        public int serialkey { get; set; }
        public string tablename { get; set; }
        public string tmtransmitflag { get; set; }
        public string transmitbatch { get; set; }
        public string transmitflag { get; set; }
        public string transmitflag2 { get; set; }
        public string transmitflag3 { get; set; }
        public string transmitflag4 { get; set; }
        public string transmitflag5 { get; set; }
        public string transmitflag6 { get; set; }
        public string transmitflag7 { get; set; }
        public string transmitflag8 { get; set; }
        public string transmitflag9 { get; set; }
        public string whseid { get; set; }
        public string jsonMessage { get; set; }
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Adjustment
    {

        private string serialKeyField;
        private string Lottable03Field;
        private string Lottable04Field;
        private string Lottable05Field;
        private string ext_udf_str1Field;

        private string transmitLogKeyField;

        private string addDateField;

        private uint itrnKeyField;

        private string tranTypeField;

        private string storerKeyField;

        private string skuKeyField;

        private string lotField;

        private uint sourceKeyField;

        private string sourceTypeField;

        private string statusField;

        private string lottable01Field;

        private string lottable02Field;

        private decimal quantityField;

        private string packKeyField;

        private string unitOfMeasureField;

        private string receiptKeyField;

        private string receiptLineNumberField;

        private string adjustmentAddDateField;

        private string holdCodeField;

        private string countSequenceField;

        private AdjustmentStorer storerField;

        private AdjustmentStorerAccountingEntity[] storerAccountingEntityField;

        private AdjustmentCommodity commodityField;

        private AdjustmentAdjustmentDetail adjustmentDetailField;

        private AdjustmentPack packField;

        private AdjustmentLotAttribute lotAttributeField;

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
        public string Lottable03
        {
            get
            {
                return this.Lottable03Field;
            }
            set
            {
                this.Lottable03Field = value;
            }
        }
        public string Lottable04
        {
            get
            {
                return this.Lottable04Field;
            }
            set
            {
                this.Lottable04Field = value;
            }
        }
        public string Lottable05
        {
            get
            {
                return this.Lottable05Field;
            }
            set
            {
                this.Lottable05Field = value;
            }
        }
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
        public uint ItrnKey
        {
            get
            {
                return this.itrnKeyField;
            }
            set
            {
                this.itrnKeyField = value;
            }
        }

        /// <remarks/>
        public string TranType
        {
            get
            {
                return this.tranTypeField;
            }
            set
            {
                this.tranTypeField = value;
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
        public string SkuKey
        {
            get
            {
                return this.skuKeyField;
            }
            set
            {
                this.skuKeyField = value;
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
        public uint SourceKey
        {
            get
            {
                return this.sourceKeyField;
            }
            set
            {
                this.sourceKeyField = value;
            }
        }

        /// <remarks/>
        public string SourceType
        {
            get
            {
                return this.sourceTypeField;
            }
            set
            {
                this.sourceTypeField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public string Lottable01
        {
            get
            {
                return this.lottable01Field;
            }
            set
            {
                this.lottable01Field = value;
            }
        }

        /// <remarks/>
        public string Lottable02
        {
            get
            {
                return this.lottable02Field;
            }
            set
            {
                this.lottable02Field = value;
            }
        }

        /// <remarks/>
        public decimal Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        public string PackKey
        {
            get
            {
                return this.packKeyField;
            }
            set
            {
                this.packKeyField = value;
            }
        }

        /// <remarks/>
        public string UnitOfMeasure
        {
            get
            {
                return this.unitOfMeasureField;
            }
            set
            {
                this.unitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public string ReceiptKey
        {
            get
            {
                return this.receiptKeyField;
            }
            set
            {
                this.receiptKeyField = value;
            }
        }

        /// <remarks/>
        public string ReceiptLineNumber
        {
            get
            {
                return this.receiptLineNumberField;
            }
            set
            {
                this.receiptLineNumberField = value;
            }
        }

        /// <remarks/>
        public string AdjustmentAddDate
        {
            get
            {
                return this.adjustmentAddDateField;
            }
            set
            {
                this.adjustmentAddDateField = value;
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
        public AdjustmentStorer Storer
        {
            get
            {
                return this.storerField;
            }
            set
            {
                this.storerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StorerAccountingEntity")]
        public AdjustmentStorerAccountingEntity[] StorerAccountingEntity
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

        /// <remarks/>
        public AdjustmentCommodity Commodity
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
        public AdjustmentAdjustmentDetail AdjustmentDetail
        {
            get
            {
                return this.adjustmentDetailField;
            }
            set
            {
                this.adjustmentDetailField = value;
            }
        }

        /// <remarks/>
        public AdjustmentPack Pack
        {
            get
            {
                return this.packField;
            }
            set
            {
                this.packField = value;
            }
        }

        /// <remarks/>
        public AdjustmentLotAttribute LotAttribute
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AdjustmentStorer
    {

        private string facilityField;

        private string accountingEntityField;

        private string measureCodeField;

        private string wgtUOMField;

        private string dimenUOMField;

        private string cubeUOMField;

        private string currCodeField;

        private string taxGroupField;

        private string defCorpCodeField;

        private string surchgBaseTempField;

        private string ambTemperatureField;

        private string planDaysField;

        private string archivePlanningDaysField;

        private string archiveReportingDataField;

        private string planEnabledField;

        private decimal defaultHourlyRateField;

        private string distCalcMethodField;

        private string maxCornerAngleField;

        private string saveStandardsAuditField;

        private string address5Field;

        private string address6Field;

        /// <remarks/>
        public string Facility
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
        public string MeasureCode
        {
            get
            {
                return this.measureCodeField;
            }
            set
            {
                this.measureCodeField = value;
            }
        }

        /// <remarks/>
        public string WgtUOM
        {
            get
            {
                return this.wgtUOMField;
            }
            set
            {
                this.wgtUOMField = value;
            }
        }

        /// <remarks/>
        public string DimenUOM
        {
            get
            {
                return this.dimenUOMField;
            }
            set
            {
                this.dimenUOMField = value;
            }
        }

        /// <remarks/>
        public string CubeUOM
        {
            get
            {
                return this.cubeUOMField;
            }
            set
            {
                this.cubeUOMField = value;
            }
        }

        /// <remarks/>
        public string CurrCode
        {
            get
            {
                return this.currCodeField;
            }
            set
            {
                this.currCodeField = value;
            }
        }

        /// <remarks/>
        public string TaxGroup
        {
            get
            {
                return this.taxGroupField;
            }
            set
            {
                this.taxGroupField = value;
            }
        }

        /// <remarks/>
        public string DefCorpCode
        {
            get
            {
                return this.defCorpCodeField;
            }
            set
            {
                this.defCorpCodeField = value;
            }
        }

        /// <remarks/>
        public string SurchgBaseTemp
        {
            get
            {
                return this.surchgBaseTempField;
            }
            set
            {
                this.surchgBaseTempField = value;
            }
        }

        /// <remarks/>
        public string AmbTemperature
        {
            get
            {
                return this.ambTemperatureField;
            }
            set
            {
                this.ambTemperatureField = value;
            }
        }

        /// <remarks/>
        public string PlanDays
        {
            get
            {
                return this.planDaysField;
            }
            set
            {
                this.planDaysField = value;
            }
        }

        /// <remarks/>
        public string ArchivePlanningDays
        {
            get
            {
                return this.archivePlanningDaysField;
            }
            set
            {
                this.archivePlanningDaysField = value;
            }
        }

        /// <remarks/>
        public string ArchiveReportingData
        {
            get
            {
                return this.archiveReportingDataField;
            }
            set
            {
                this.archiveReportingDataField = value;
            }
        }

        /// <remarks/>
        public string PlanEnabled
        {
            get
            {
                return this.planEnabledField;
            }
            set
            {
                this.planEnabledField = value;
            }
        }

        /// <remarks/>
        public decimal DefaultHourlyRate
        {
            get
            {
                return this.defaultHourlyRateField;
            }
            set
            {
                this.defaultHourlyRateField = value;
            }
        }

        /// <remarks/>
        public string DistCalcMethod
        {
            get
            {
                return this.distCalcMethodField;
            }
            set
            {
                this.distCalcMethodField = value;
            }
        }

        /// <remarks/>
        public string MaxCornerAngle
        {
            get
            {
                return this.maxCornerAngleField;
            }
            set
            {
                this.maxCornerAngleField = value;
            }
        }

        /// <remarks/>
        public string SaveStandardsAudit
        {
            get
            {
                return this.saveStandardsAuditField;
            }
            set
            {
                this.saveStandardsAuditField = value;
            }
        }

        /// <remarks/>
        public string Address5
        {
            get
            {
                return this.address5Field;
            }
            set
            {
                this.address5Field = value;
            }
        }

        /// <remarks/>
        public string Address6
        {
            get
            {
                return this.address6Field;
            }
            set
            {
                this.address6Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AdjustmentStorerAccountingEntity
    {

        private string accountingEntityField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AdjustmentCommodity
    {

        private string storerKeyField;

        private string skuField;

        private string descrField;

        private string nonStockedIndicatorField;

        private string oCDFlagField;

        private string oCDLabel1Field;

        private string oCDLabel2Field;

        private string accountingEntityField;

        private string fillQtyUOMField;

        private string recurCodeField;

        private string wgtUOMField;

        private string dimenUOMField;

        private string cubeUOMField;

        private string storageTypeField;

        private string nMFCClassField;

        private string mateabilityCodeField;

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
        public string Descr
        {
            get
            {
                return this.descrField;
            }
            set
            {
                this.descrField = value;
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
        public string OCDFlag
        {
            get
            {
                return this.oCDFlagField;
            }
            set
            {
                this.oCDFlagField = value;
            }
        }

        /// <remarks/>
        public string OCDLabel1
        {
            get
            {
                return this.oCDLabel1Field;
            }
            set
            {
                this.oCDLabel1Field = value;
            }
        }

        /// <remarks/>
        public string OCDLabel2
        {
            get
            {
                return this.oCDLabel2Field;
            }
            set
            {
                this.oCDLabel2Field = value;
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
        public string FillQtyUOM
        {
            get
            {
                return this.fillQtyUOMField;
            }
            set
            {
                this.fillQtyUOMField = value;
            }
        }

        /// <remarks/>
        public string RecurCode
        {
            get
            {
                return this.recurCodeField;
            }
            set
            {
                this.recurCodeField = value;
            }
        }

        /// <remarks/>
        public string WgtUOM
        {
            get
            {
                return this.wgtUOMField;
            }
            set
            {
                this.wgtUOMField = value;
            }
        }

        /// <remarks/>
        public string DimenUOM
        {
            get
            {
                return this.dimenUOMField;
            }
            set
            {
                this.dimenUOMField = value;
            }
        }

        /// <remarks/>
        public string CubeUOM
        {
            get
            {
                return this.cubeUOMField;
            }
            set
            {
                this.cubeUOMField = value;
            }
        }

        /// <remarks/>
        public string StorageType
        {
            get
            {
                return this.storageTypeField;
            }
            set
            {
                this.storageTypeField = value;
            }
        }

        /// <remarks/>
        public string NMFCClass
        {
            get
            {
                return this.nMFCClassField;
            }
            set
            {
                this.nMFCClassField = value;
            }
        }

        /// <remarks/>
        public string MateabilityCode
        {
            get
            {
                return this.mateabilityCodeField;
            }
            set
            {
                this.mateabilityCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AdjustmentAdjustmentDetail
    {

        private string notesField;

        private string reasonCodeField;

        /// <remarks/>
        public string Notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }

        /// <remarks/>
        public string ReasonCode
        {
            get
            {
                return this.reasonCodeField;
            }
            set
            {
                this.reasonCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AdjustmentPack
    {

        private string packUOM3Field;

        /// <remarks/>
        public string PackUOM3
        {
            get
            {
                return this.packUOM3Field;
            }
            set
            {
                this.packUOM3Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AdjustmentLotAttribute
    {

        private string lottable09Field;

        private string lottable10Field;

        /// <remarks/>
        public string Lottable09
        {
            get
            {
                return this.lottable09Field;
            }
            set
            {
                this.lottable09Field = value;
            }
        }

        /// <remarks/>
        public string Lottable10
        {
            get
            {
                return this.lottable10Field;
            }
            set
            {
                this.lottable10Field = value;
            }
        }
    }




}
