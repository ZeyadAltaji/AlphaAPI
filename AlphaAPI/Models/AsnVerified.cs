namespace AlphaAPI.Models
{



    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AsnVerified
    {

        private string serialKeyField;

        private string transmitLogKeyField;

        private string addDateField;

        private AsnVerifiedAsnHeader asnHeaderField;

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
        public AsnVerifiedAsnHeader AsnHeader
        {
            get
            {
                return this.asnHeaderField;
            }
            set
            {
                this.asnHeaderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AsnVerifiedAsnHeader
    {

        private string externReceiptKeyField;

        private string receiptKeyField;

        private string adddateField;

        private string editdateField;

        private string notesField;

        private string typeField;

        private string pOKeyField;

        private string carrierReferenceField;

        private string externalReceiptKey2Field;

        private string statusCodeField;

        private string effectiveDateField;

        private string originCountryField;

        private string transportationModeField;

        private string carrierKeyField;

        private string carrierNameField;

        private string carrierAddress1Field;

        private string carrierAddress2Field;

        private string carrierCityField;

        private string carrierStateField;

        private string carrierZipField;

        private string carrierCountryField;

        private string carrierPhone1Field;

        private string warehouseReferenceField;

        private string adviceNumberField;

        private string adviceDateField;

        private string expectedReceiptDateField;

        private string sourceLocationField;

        private string sourceVersionField;

        private string referenceTypeField;

        private string referenceDocumentField;

        private string referenceLocationField;

        private string referenceAccountingEntityField;

        private string termsNoteField;

        private string b_StorerKeyField;

        private string b_CompanyField;

        private string b_Address1Field;

        private string b_Address2Field;

        private string b_Address3Field;

        private string b_Address4Field;

        private string b_CityField;

        private string b_StateField;

        private string b_ZipField;

        private string b_CountryField;

        private string b_Phone1Field;

        private string accountingEntityField;

        private string earliestShipDateField;

        private string requiredShipDateField;

        private string promisedShipDateField;

        private string plannedShipDateField;

        private string earliestDeliveryDateField;

        private string requiredDeliveryDateField;

        private string promisedDeliveryDateField;

        private string plannedDeliveryDateField;

        private string supplierCodeField;

        private string supplierNameField;

        private string shipFromAddressLine1Field;

        private string shipFromAddressLine2Field;

        private string shipFromAddressLine3Field;

        private string shipFromAddressLine4Field;

        private string shipFromCityField;

        private string shipFromStateField;

        private string shipFromZipField;

        private string shipFromISOCountryField;

        private string returnFromPartyField;

        private string ext_udf_str1Field;

        private string ext_udf_str2Field;

        private string eXTERNALRECEIPTKEY2Field;

        private string susr1Field;
        private string susr5Field;

        private AsnVerifiedAsnHeaderFacility facilityField;

        private AsnVerifiedAsnHeaderAsnDetail[] asnDetailField;


        /// <remarks/>
        public string ExternReceiptKey
        {
            get
            {
                return this.externReceiptKeyField;
            }
            set
            {
                this.externReceiptKeyField = value;
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
        public string Adddate
        {
            get
            {
                return this.adddateField;
            }
            set
            {
                this.adddateField = value;
            }
        }

        /// <remarks/>
        public string Editdate
        {
            get
            {
                return this.editdateField;
            }
            set
            {
                this.editdateField = value;
            }
        }

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
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string POKey
        {
            get
            {
                return this.pOKeyField;
            }
            set
            {
                this.pOKeyField = value;
            }
        }

        /// <remarks/>
        public string CarrierReference
        {
            get
            {
                return this.carrierReferenceField;
            }
            set
            {
                this.carrierReferenceField = value;
            }
        }

        /// <remarks/>
        public string ExternalReceiptKey2
        {
            get
            {
                return this.externalReceiptKey2Field;
            }
            set
            {
                this.externalReceiptKey2Field = value;
            }
        }

        /// <remarks/>
        public string StatusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }

        /// <remarks/>
        public string EffectiveDate
        {
            get
            {
                return this.effectiveDateField;
            }
            set
            {
                this.effectiveDateField = value;
            }
        }

        /// <remarks/>
        public string OriginCountry
        {
            get
            {
                return this.originCountryField;
            }
            set
            {
                this.originCountryField = value;
            }
        }

        /// <remarks/>
        public string TransportationMode
        {
            get
            {
                return this.transportationModeField;
            }
            set
            {
                this.transportationModeField = value;
            }
        }

        /// <remarks/>
        public string CarrierKey
        {
            get
            {
                return this.carrierKeyField;
            }
            set
            {
                this.carrierKeyField = value;
            }
        }

        /// <remarks/>
        public string CarrierName
        {
            get
            {
                return this.carrierNameField;
            }
            set
            {
                this.carrierNameField = value;
            }
        }

        /// <remarks/>
        public string CarrierAddress1
        {
            get
            {
                return this.carrierAddress1Field;
            }
            set
            {
                this.carrierAddress1Field = value;
            }
        }

        /// <remarks/>
        public string CarrierAddress2
        {
            get
            {
                return this.carrierAddress2Field;
            }
            set
            {
                this.carrierAddress2Field = value;
            }
        }

        /// <remarks/>
        public string CarrierCity
        {
            get
            {
                return this.carrierCityField;
            }
            set
            {
                this.carrierCityField = value;
            }
        }

        /// <remarks/>
        public string CarrierState
        {
            get
            {
                return this.carrierStateField;
            }
            set
            {
                this.carrierStateField = value;
            }
        }

        /// <remarks/>
        public string CarrierZip
        {
            get
            {
                return this.carrierZipField;
            }
            set
            {
                this.carrierZipField = value;
            }
        }

        /// <remarks/>
        public string CarrierCountry
        {
            get
            {
                return this.carrierCountryField;
            }
            set
            {
                this.carrierCountryField = value;
            }
        }

        /// <remarks/>
        public string CarrierPhone1
        {
            get
            {
                return this.carrierPhone1Field;
            }
            set
            {
                this.carrierPhone1Field = value;
            }
        }

        /// <remarks/>
        public string WarehouseReference
        {
            get
            {
                return this.warehouseReferenceField;
            }
            set
            {
                this.warehouseReferenceField = value;
            }
        }

        /// <remarks/>
        public string AdviceNumber
        {
            get
            {
                return this.adviceNumberField;
            }
            set
            {
                this.adviceNumberField = value;
            }
        }

        /// <remarks/>
        public string AdviceDate
        {
            get
            {
                return this.adviceDateField;
            }
            set
            {
                this.adviceDateField = value;
            }
        }

        /// <remarks/>
        public string ExpectedReceiptDate
        {
            get
            {
                return this.expectedReceiptDateField;
            }
            set
            {
                this.expectedReceiptDateField = value;
            }
        }

        /// <remarks/>
        public string SourceLocation
        {
            get
            {
                return this.sourceLocationField;
            }
            set
            {
                this.sourceLocationField = value;
            }
        }

        /// <remarks/>
        public string SourceVersion
        {
            get
            {
                return this.sourceVersionField;
            }
            set
            {
                this.sourceVersionField = value;
            }
        }

        /// <remarks/>
        public string ReferenceType
        {
            get
            {
                return this.referenceTypeField;
            }
            set
            {
                this.referenceTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceDocument
        {
            get
            {
                return this.referenceDocumentField;
            }
            set
            {
                this.referenceDocumentField = value;
            }
        }

        /// <remarks/>
        public string ReferenceLocation
        {
            get
            {
                return this.referenceLocationField;
            }
            set
            {
                this.referenceLocationField = value;
            }
        }

        /// <remarks/>
        public string ReferenceAccountingEntity
        {
            get
            {
                return this.referenceAccountingEntityField;
            }
            set
            {
                this.referenceAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public string TermsNote
        {
            get
            {
                return this.termsNoteField;
            }
            set
            {
                this.termsNoteField = value;
            }
        }

        /// <remarks/>
        public string b_StorerKey
        {
            get
            {
                return this.b_StorerKeyField;
            }
            set
            {
                this.b_StorerKeyField = value;
            }
        }

        /// <remarks/>
        public string b_Company
        {
            get
            {
                return this.b_CompanyField;
            }
            set
            {
                this.b_CompanyField = value;
            }
        }

        /// <remarks/>
        public string b_Address1
        {
            get
            {
                return this.b_Address1Field;
            }
            set
            {
                this.b_Address1Field = value;
            }
        }

        /// <remarks/>
        public string b_Address2
        {
            get
            {
                return this.b_Address2Field;
            }
            set
            {
                this.b_Address2Field = value;
            }
        }

        /// <remarks/>
        public string b_Address3
        {
            get
            {
                return this.b_Address3Field;
            }
            set
            {
                this.b_Address3Field = value;
            }
        }

        /// <remarks/>
        public string b_Address4
        {
            get
            {
                return this.b_Address4Field;
            }
            set
            {
                this.b_Address4Field = value;
            }
        }

        /// <remarks/>
        public string b_City
        {
            get
            {
                return this.b_CityField;
            }
            set
            {
                this.b_CityField = value;
            }
        }

        /// <remarks/>
        public string b_State
        {
            get
            {
                return this.b_StateField;
            }
            set
            {
                this.b_StateField = value;
            }
        }

        /// <remarks/>
        public string b_Zip
        {
            get
            {
                return this.b_ZipField;
            }
            set
            {
                this.b_ZipField = value;
            }
        }

        /// <remarks/>
        public string b_Country
        {
            get
            {
                return this.b_CountryField;
            }
            set
            {
                this.b_CountryField = value;
            }
        }

        /// <remarks/>
        public string b_Phone1
        {
            get
            {
                return this.b_Phone1Field;
            }
            set
            {
                this.b_Phone1Field = value;
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
        public string EarliestShipDate
        {
            get
            {
                return this.earliestShipDateField;
            }
            set
            {
                this.earliestShipDateField = value;
            }
        }

        /// <remarks/>
        public string RequiredShipDate
        {
            get
            {
                return this.requiredShipDateField;
            }
            set
            {
                this.requiredShipDateField = value;
            }
        }

        /// <remarks/>
        public string PromisedShipDate
        {
            get
            {
                return this.promisedShipDateField;
            }
            set
            {
                this.promisedShipDateField = value;
            }
        }

        /// <remarks/>
        public string PlannedShipDate
        {
            get
            {
                return this.plannedShipDateField;
            }
            set
            {
                this.plannedShipDateField = value;
            }
        }

        /// <remarks/>
        public string EarliestDeliveryDate
        {
            get
            {
                return this.earliestDeliveryDateField;
            }
            set
            {
                this.earliestDeliveryDateField = value;
            }
        }

        /// <remarks/>
        public string RequiredDeliveryDate
        {
            get
            {
                return this.requiredDeliveryDateField;
            }
            set
            {
                this.requiredDeliveryDateField = value;
            }
        }

        /// <remarks/>
        public string PromisedDeliveryDate
        {
            get
            {
                return this.promisedDeliveryDateField;
            }
            set
            {
                this.promisedDeliveryDateField = value;
            }
        }

        /// <remarks/>
        public string PlannedDeliveryDate
        {
            get
            {
                return this.plannedDeliveryDateField;
            }
            set
            {
                this.plannedDeliveryDateField = value;
            }
        }

        /// <remarks/>
        public string SupplierCode
        {
            get
            {
                return this.supplierCodeField;
            }
            set
            {
                this.supplierCodeField = value;
            }
        }

        /// <remarks/>
        public string SupplierName
        {
            get
            {
                return this.supplierNameField;
            }
            set
            {
                this.supplierNameField = value;
            }
        }

        /// <remarks/>
        public string ShipFromAddressLine1
        {
            get
            {
                return this.shipFromAddressLine1Field;
            }
            set
            {
                this.shipFromAddressLine1Field = value;
            }
        }

        /// <remarks/>
        public string ShipFromAddressLine2
        {
            get
            {
                return this.shipFromAddressLine2Field;
            }
            set
            {
                this.shipFromAddressLine2Field = value;
            }
        }

        /// <remarks/>
        public string ShipFromAddressLine3
        {
            get
            {
                return this.shipFromAddressLine3Field;
            }
            set
            {
                this.shipFromAddressLine3Field = value;
            }
        }

        /// <remarks/>
        public string ShipFromAddressLine4
        {
            get
            {
                return this.shipFromAddressLine4Field;
            }
            set
            {
                this.shipFromAddressLine4Field = value;
            }
        }

        /// <remarks/>
        public string ShipFromCity
        {
            get
            {
                return this.shipFromCityField;
            }
            set
            {
                this.shipFromCityField = value;
            }
        }

        /// <remarks/>
        public string ShipFromState
        {
            get
            {
                return this.shipFromStateField;
            }
            set
            {
                this.shipFromStateField = value;
            }
        }

        /// <remarks/>
        public string ShipFromZip
        {
            get
            {
                return this.shipFromZipField;
            }
            set
            {
                this.shipFromZipField = value;
            }
        }

        /// <remarks/>
        public string ShipFromISOCountry
        {
            get
            {
                return this.shipFromISOCountryField;
            }
            set
            {
                this.shipFromISOCountryField = value;
            }
        }

        /// <remarks/>
        public string ReturnFromParty
        {
            get
            {
                return this.returnFromPartyField;
            }
            set
            {
                this.returnFromPartyField = value;
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
        public string ext_udf_str2
        {
            get
            {
                return this.ext_udf_str2Field;
            }
            set
            {
                this.ext_udf_str2Field = value;
            }
        }

        /// <remarks/>
        public string EXTERNALRECEIPTKEY2
        {
            get
            {
                return this.eXTERNALRECEIPTKEY2Field;
            }
            set
            {
                this.eXTERNALRECEIPTKEY2Field = value;
            }
        }

        /// <remarks/>
        public string susr1
        {
            get
            {
                return this.susr1Field;
            }
            set
            {
                this.susr1Field = value;
            }
        }
        public string susr5
        {
            get
            {
                return this.susr5Field;
            }
            set
            {
                this.susr5Field = value;
            }
        }
        /// <remarks/>
        public AsnVerifiedAsnHeaderFacility Facility
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
        [System.Xml.Serialization.XmlElementAttribute("AsnDetail")]
        public AsnVerifiedAsnHeaderAsnDetail[] AsnDetail
        {
            get
            {
                return this.asnDetailField;
            }
            set
            {
                this.asnDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AsnVerifiedAsnHeaderFacility
    {

        private string a_StorerKeyField;

        private string a_CompanyField;

        private string a_Address1Field;

        private string a_Address2Field;

        private string a_Address3Field;

        private string a_Address4Field;

        private string a_CityField;

        private string a_StateField;

        private string a_ZipField;

        private string a_CountryField;

        private string a_Phone1Field;

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
        public string a_StorerKey
        {
            get
            {
                return this.a_StorerKeyField;
            }
            set
            {
                this.a_StorerKeyField = value;
            }
        }

        /// <remarks/>
        public string a_Company
        {
            get
            {
                return this.a_CompanyField;
            }
            set
            {
                this.a_CompanyField = value;
            }
        }

        /// <remarks/>
        public string a_Address1
        {
            get
            {
                return this.a_Address1Field;
            }
            set
            {
                this.a_Address1Field = value;
            }
        }

        /// <remarks/>
        public string a_Address2
        {
            get
            {
                return this.a_Address2Field;
            }
            set
            {
                this.a_Address2Field = value;
            }
        }

        /// <remarks/>
        public string a_Address3
        {
            get
            {
                return this.a_Address3Field;
            }
            set
            {
                this.a_Address3Field = value;
            }
        }

        /// <remarks/>
        public string a_Address4
        {
            get
            {
                return this.a_Address4Field;
            }
            set
            {
                this.a_Address4Field = value;
            }
        }

        /// <remarks/>
        public string a_City
        {
            get
            {
                return this.a_CityField;
            }
            set
            {
                this.a_CityField = value;
            }
        }

        /// <remarks/>
        public string a_State
        {
            get
            {
                return this.a_StateField;
            }
            set
            {
                this.a_StateField = value;
            }
        }

        /// <remarks/>
        public string a_Zip
        {
            get
            {
                return this.a_ZipField;
            }
            set
            {
                this.a_ZipField = value;
            }
        }

        /// <remarks/>
        public string a_Country
        {
            get
            {
                return this.a_CountryField;
            }
            set
            {
                this.a_CountryField = value;
            }
        }

        /// <remarks/>
        public string a_Phone1
        {
            get
            {
                return this.a_Phone1Field;
            }
            set
            {
                this.a_Phone1Field = value;
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
    public partial class AsnVerifiedAsnHeaderAsnDetail
    {

        private string whseIDField;

        private string receiptKeyField;

        private string receiptLineNumberField;

        private string altSkuField;

        private string notesField;

        private string lottable01Field;

        private string lottable02Field;

        private string lottable03Field;

        private string lottable04Field;

        private string lottable05Field;

        private string lottable06Field;

        private string lottable07Field;

        private string lottable08Field;

        private string lottable09Field;

        private string lottable10Field;

        private decimal qtyExpectedField;

        private decimal qtyReceivedField;

        private string packKeyField;

        private decimal qtyRejectedField;

        private decimal packingSlipQtyField;

        private string editDateField;

        private string addDateField;

        private string pOKeyField;

        private string externLineNoField;

        private ushort toLotField;

        private string toIDField;

        private string sourceLocationField;

        private string sourceVersionField;

        private string referenceTypeField;

        private string referenceDocumentField;

        private string referenceLocationField;

        private string referenceLineField;

        private string referenceAccountingEntityField;

        private string subLineNumberField;

        private string storerKeyField;

        private string skuField;

        private string nonStockedIndicatorField;

        private decimal stdGrossWgtField;

        private decimal stdCubeField;

        private string referenceScheduleLineField;

        private string requisitionDocumentField;

        private string requisitionAccountingEntityField;

        private string requisitionLocationField;

        private string requisitionLineField;

        private string requisitionScheduleLineField;

        private string purchaseOrderDocumentField;

        private string purchaseOrderAccountingEntityField;

        private string purchaseOrderLocationField;

        private string purchaseOrderLineField;

        private string purchaseOrderScheduleLineField;

        private string salesOrderDocumentField;

        private string salesOrderAccountingEntityField;

        private string salesOrderLocationField;

        private string salesOrderLineField;

        private string salesOrderScheduleLineField;

        private string productionOrderDocumentField;

        private string productionOrderAccEntityField;

        private string productionOrderLocationField;

        private string productionOrderLineField;

        private string productionOrderScheduleLineField;

        private decimal tareWgtField;

        private AsnVerifiedAsnHeaderAsnDetailITRNCountSequence iTRNCountSequenceField;

        private AsnVerifiedAsnHeaderAsnDetailITRNHoldCodes iTRNHoldCodesField;

        private AsnVerifiedAsnHeaderAsnDetailPack packField;

        private AsnVerifiedAsnHeaderAsnDetailCommodity commodityField;

        /// <remarks/>
        public string WhseID
        {
            get
            {
                return this.whseIDField;
            }
            set
            {
                this.whseIDField = value;
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
        public string AltSku
        {
            get
            {
                return this.altSkuField;
            }
            set
            {
                this.altSkuField = value;
            }
        }

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
        public string Lottable06
        {
            get
            {
                return this.lottable06Field;
            }
            set
            {
                this.lottable06Field = value;
            }
        }

        /// <remarks/>
        public string Lottable07
        {
            get
            {
                return this.lottable07Field;
            }
            set
            {
                this.lottable07Field = value;
            }
        }

        /// <remarks/>
        public string Lottable08
        {
            get
            {
                return this.lottable08Field;
            }
            set
            {
                this.lottable08Field = value;
            }
        }

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

        /// <remarks/>
        public decimal QtyExpected
        {
            get
            {
                return this.qtyExpectedField;
            }
            set
            {
                this.qtyExpectedField = value;
            }
        }

        /// <remarks/>
        public decimal QtyReceived
        {
            get
            {
                return this.qtyReceivedField;
            }
            set
            {
                this.qtyReceivedField = value;
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
        public decimal QtyRejected
        {
            get
            {
                return this.qtyRejectedField;
            }
            set
            {
                this.qtyRejectedField = value;
            }
        }

        /// <remarks/>
        public decimal PackingSlipQty
        {
            get
            {
                return this.packingSlipQtyField;
            }
            set
            {
                this.packingSlipQtyField = value;
            }
        }

        /// <remarks/>
        public string EditDate
        {
            get
            {
                return this.editDateField;
            }
            set
            {
                this.editDateField = value;
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
        public string POKey
        {
            get
            {
                return this.pOKeyField;
            }
            set
            {
                this.pOKeyField = value;
            }
        }

        /// <remarks/>
        public string ExternLineNo
        {
            get
            {
                return this.externLineNoField;
            }
            set
            {
                this.externLineNoField = value;
            }
        }

        /// <remarks/>
        public ushort ToLot
        {
            get
            {
                return this.toLotField;
            }
            set
            {
                this.toLotField = value;
            }
        }

        /// <remarks/>
        public string ToID
        {
            get
            {
                return this.toIDField;
            }
            set
            {
                this.toIDField = value;
            }
        }

        /// <remarks/>
        public string SourceLocation
        {
            get
            {
                return this.sourceLocationField;
            }
            set
            {
                this.sourceLocationField = value;
            }
        }

        /// <remarks/>
        public string SourceVersion
        {
            get
            {
                return this.sourceVersionField;
            }
            set
            {
                this.sourceVersionField = value;
            }
        }

        /// <remarks/>
        public string ReferenceType
        {
            get
            {
                return this.referenceTypeField;
            }
            set
            {
                this.referenceTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceDocument
        {
            get
            {
                return this.referenceDocumentField;
            }
            set
            {
                this.referenceDocumentField = value;
            }
        }

        /// <remarks/>
        public string ReferenceLocation
        {
            get
            {
                return this.referenceLocationField;
            }
            set
            {
                this.referenceLocationField = value;
            }
        }

        /// <remarks/>
        public string ReferenceLine
        {
            get
            {
                return this.referenceLineField;
            }
            set
            {
                this.referenceLineField = value;
            }
        }

        /// <remarks/>
        public string ReferenceAccountingEntity
        {
            get
            {
                return this.referenceAccountingEntityField;
            }
            set
            {
                this.referenceAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public string SubLineNumber
        {
            get
            {
                return this.subLineNumberField;
            }
            set
            {
                this.subLineNumberField = value;
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
        public decimal StdGrossWgt
        {
            get
            {
                return this.stdGrossWgtField;
            }
            set
            {
                this.stdGrossWgtField = value;
            }
        }

        /// <remarks/>
        public decimal StdCube
        {
            get
            {
                return this.stdCubeField;
            }
            set
            {
                this.stdCubeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceScheduleLine
        {
            get
            {
                return this.referenceScheduleLineField;
            }
            set
            {
                this.referenceScheduleLineField = value;
            }
        }

        /// <remarks/>
        public string RequisitionDocument
        {
            get
            {
                return this.requisitionDocumentField;
            }
            set
            {
                this.requisitionDocumentField = value;
            }
        }

        /// <remarks/>
        public string RequisitionAccountingEntity
        {
            get
            {
                return this.requisitionAccountingEntityField;
            }
            set
            {
                this.requisitionAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public string RequisitionLocation
        {
            get
            {
                return this.requisitionLocationField;
            }
            set
            {
                this.requisitionLocationField = value;
            }
        }

        /// <remarks/>
        public string RequisitionLine
        {
            get
            {
                return this.requisitionLineField;
            }
            set
            {
                this.requisitionLineField = value;
            }
        }

        /// <remarks/>
        public string RequisitionScheduleLine
        {
            get
            {
                return this.requisitionScheduleLineField;
            }
            set
            {
                this.requisitionScheduleLineField = value;
            }
        }

        /// <remarks/>
        public string PurchaseOrderDocument
        {
            get
            {
                return this.purchaseOrderDocumentField;
            }
            set
            {
                this.purchaseOrderDocumentField = value;
            }
        }

        /// <remarks/>
        public string PurchaseOrderAccountingEntity
        {
            get
            {
                return this.purchaseOrderAccountingEntityField;
            }
            set
            {
                this.purchaseOrderAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public string PurchaseOrderLocation
        {
            get
            {
                return this.purchaseOrderLocationField;
            }
            set
            {
                this.purchaseOrderLocationField = value;
            }
        }

        /// <remarks/>
        public string PurchaseOrderLine
        {
            get
            {
                return this.purchaseOrderLineField;
            }
            set
            {
                this.purchaseOrderLineField = value;
            }
        }

        /// <remarks/>
        public string PurchaseOrderScheduleLine
        {
            get
            {
                return this.purchaseOrderScheduleLineField;
            }
            set
            {
                this.purchaseOrderScheduleLineField = value;
            }
        }

        /// <remarks/>
        public string SalesOrderDocument
        {
            get
            {
                return this.salesOrderDocumentField;
            }
            set
            {
                this.salesOrderDocumentField = value;
            }
        }

        /// <remarks/>
        public string SalesOrderAccountingEntity
        {
            get
            {
                return this.salesOrderAccountingEntityField;
            }
            set
            {
                this.salesOrderAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public string SalesOrderLocation
        {
            get
            {
                return this.salesOrderLocationField;
            }
            set
            {
                this.salesOrderLocationField = value;
            }
        }

        /// <remarks/>
        public string SalesOrderLine
        {
            get
            {
                return this.salesOrderLineField;
            }
            set
            {
                this.salesOrderLineField = value;
            }
        }

        /// <remarks/>
        public string SalesOrderScheduleLine
        {
            get
            {
                return this.salesOrderScheduleLineField;
            }
            set
            {
                this.salesOrderScheduleLineField = value;
            }
        }

        /// <remarks/>
        public string ProductionOrderDocument
        {
            get
            {
                return this.productionOrderDocumentField;
            }
            set
            {
                this.productionOrderDocumentField = value;
            }
        }

        /// <remarks/>
        public string ProductionOrderAccEntity
        {
            get
            {
                return this.productionOrderAccEntityField;
            }
            set
            {
                this.productionOrderAccEntityField = value;
            }
        }

        /// <remarks/>
        public string ProductionOrderLocation
        {
            get
            {
                return this.productionOrderLocationField;
            }
            set
            {
                this.productionOrderLocationField = value;
            }
        }

        /// <remarks/>
        public string ProductionOrderLine
        {
            get
            {
                return this.productionOrderLineField;
            }
            set
            {
                this.productionOrderLineField = value;
            }
        }

        /// <remarks/>
        public string ProductionOrderScheduleLine
        {
            get
            {
                return this.productionOrderScheduleLineField;
            }
            set
            {
                this.productionOrderScheduleLineField = value;
            }
        }

        /// <remarks/>
        public decimal TareWgt
        {
            get
            {
                return this.tareWgtField;
            }
            set
            {
                this.tareWgtField = value;
            }
        }

        /// <remarks/>
        public AsnVerifiedAsnHeaderAsnDetailITRNCountSequence ITRNCountSequence
        {
            get
            {
                return this.iTRNCountSequenceField;
            }
            set
            {
                this.iTRNCountSequenceField = value;
            }
        }

        /// <remarks/>
        public AsnVerifiedAsnHeaderAsnDetailITRNHoldCodes ITRNHoldCodes
        {
            get
            {
                return this.iTRNHoldCodesField;
            }
            set
            {
                this.iTRNHoldCodesField = value;
            }
        }

        /// <remarks/>
        public AsnVerifiedAsnHeaderAsnDetailPack Pack
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
        public AsnVerifiedAsnHeaderAsnDetailCommodity Commodity
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AsnVerifiedAsnHeaderAsnDetailITRNCountSequence
    {

        private string countSequenceField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AsnVerifiedAsnHeaderAsnDetailITRNHoldCodes
    {

        private string holdCodeField;

        private decimal qtyField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AsnVerifiedAsnHeaderAsnDetailPack
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
    public partial class AsnVerifiedAsnHeaderAsnDetailCommodity
    {

        private string storerKeyField;

        private string skuField;

        private string descrField;

        private string nonStockedIndicatorField;

        private string iCDFLAGField;

        private string iCDLABEL1Field;

        private string iCDLABEL2Field;

        private string accountingEntityField;

        private string fillQtyUOMField;

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
        public string ICDFLAG
        {
            get
            {
                return this.iCDFLAGField;
            }
            set
            {
                this.iCDFLAGField = value;
            }
        }

        /// <remarks/>
        public string ICDLABEL1
        {
            get
            {
                return this.iCDLABEL1Field;
            }
            set
            {
                this.iCDLABEL1Field = value;
            }
        }

        /// <remarks/>
        public string ICDLABEL2
        {
            get
            {
                return this.iCDLABEL2Field;
            }
            set
            {
                this.iCDLABEL2Field = value;
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
    }




}
