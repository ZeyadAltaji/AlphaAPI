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
    public partial class ShipmentConfirmation
    {

        private string serialKeyField;

        private string transmitLogKeyField;

        private string addDateField;

        private ShipmentConfirmationShipmentOrderHeader shipmentOrderHeaderField;

        private ShipmentConfirmationFacility facilityField;

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
        public ShipmentConfirmationShipmentOrderHeader ShipmentOrderHeader
        {
            get
            {
                return this.shipmentOrderHeaderField;
            }
            set
            {
                this.shipmentOrderHeaderField = value;
            }
        }

        /// <remarks/>
        public ShipmentConfirmationFacility Facility
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationShipmentOrderHeader
    {

        private string orderKeyField;

        private string storerKeyField;

        private string externOrderKeyField;

        private string externalOrderKey2Field;

        private string orderDateField;

        private string deliveryDateField;

        private string priorityField;

        private string consigneeKeyField;

        private string c_Contact1Field;

        private string c_Contact2Field;

        private string c_CompanyField;

        private string c_Address1Field;

        private string c_Address2Field;

        private string c_Address3Field;

        private string c_Address4Field;

        private string c_Address5Field;

        private string c_Address6Field;

        private string c_CityField;

        private string c_StateField;

        private string c_ZipField;

        private string c_CountryField;

        private string c_ISOCntryCodeField;

        private string c_Phone1Field;

        private string c_Phone2Field;

        private string c_Fax1Field;

        private string c_Fax2Field;

        private string c_Email1Field;

        private string c_Email2Field;

        private string c_VatField;

        private string buyerPOField;

        private string returnToPartyField;

        private string billToKeyField;

        private string b_Contact1Field;

        private string b_Contact2Field;

        private string b_CompanyField;

        private string b_Address1Field;

        private string b_Address2Field;

        private string b_Address3Field;

        private string b_Address4Field;

        private string b_Address5Field;

        private string b_Address6Field;

        private string b_CityField;

        private string b_StateField;

        private string b_ZipField;

        private string b_CountryField;

        private string b_ISOCntryCodeField;

        private string b_Phone1Field;

        private string b_Phone2Field;

        private string b_Fax1Field;

        private string b_Fax2Field;

        private string b_VATField;

        private string incoTermField;

        private string pmtTermField;

        private string doorField;

        private string routeField;

        private string stopField;

        private decimal openQtyField;

        private string statusField;

        private string dischargePlaceField;

        private string deliveryPlaceField;

        private string intermodalVehicleField;

        private string countryOfOriginField;

        private string updateSourceField;

        private string typeField;

        private string orderGroupField;

        private string notesField;

        private string effectiveDateField;

        private decimal item_NumberField;

        private string containerTypeField;

        private string containerQtyField;

        private string billedContainerQtyField;

        private string chepPalletIndicatorField;

        private string transportationModeField;

        private string transportationServiceField;

        private string sUsr1Field;

        private string sUsr2Field;

        private string sUsr3Field;

        private string sUsr4Field;

        private string sUsr5Field;

        private string notes2Field;

        private string oHTypeField;

        private string loadIDField;

        private string addDateField;

        private string editDateField;

        private string addWhoField;

        private string editWhoField;

        private string forte_FlagField;

        private string stageField;

        private string dc_IdField;

        private string whse_IdField;

        private string split_OrdersField;

        private string appt_StatusField;

        private string shiptogetherField;

        private string deliveryDate2Field;

        private string requestedShipDateField;

        private string actualShipDateField;

        private string deliver_DateField;

        private decimal orderValueField;

        private string externalLoadIdField;

        private string sortationLocationField;

        private string batchFlagField;

        private string bulkCartonGroupField;

        private string referenceNumField;

        private string destinationNestIdField;

        private string intransitKeyField;

        private string receiptKeyField;

        private string labelNameField;

        private string whseIdField;

        private string serialKeyField;

        private string rfidFlagField;

        private string countryDestinationField;

        private string carrierCodeField;

        private string carrierNameField;

        private string carrierAddress1Field;

        private string carrierAddress2Field;

        private string carrierCityField;

        private string carrierStateField;

        private string carrierZipField;

        private string carrierCountryField;

        private string carrierPhoneField;

        private string proNumberField;

        private string tradingPartnerField;

        private string sourceVersionField;

        private string referenceTypeField;

        private string referenceDocumentField;

        private string referenceLocationField;

        private string referenceAccountingEntityField;

        private string freightChargeAmountField;

        private string freightCostAmountField;

        private string freightChargeBaseAmountField;

        private string freightCostBaseAmountField;

        private string earliestShipDateField;

        private string promisedShipDateField;

        private string plannedShipDateField;

        private string scheduledShipDateField;

        private string earliestDeliveryDateField;

        private string promisedDelvDateField;

        private string plannedDelvDateField;

        private string scheduledDelvDateField;

        private string actualDelvDateField;

        private string carrierRouteDocumentField;

        private string carrierRouteAccountingEntityField;

        private string carrierRouteLocationField;

        private string carrierRouteVersionField;

        private string carrierRouteStatusField;

        private string tMHouseAirWayBillNumberField;

        private string tMMasterAirWayBillNumberField;

        private string tMBookingNumberField;

        private string tMHouseOceanBOLNumberField;

        private string tMMasterOceanBOLNumberField;

        private string tMEquipmentNumberField;

        private string tMSealNumberField;

        private string tMLicensePlateNumberField;

        private string tMEquipmentTypeField;

        private string tMEquipmentLengthField;

        private string tMEquipmentAttributeField;

        private string tMAirServiceLevelField;

        private string tMOceanServiceLevelField;

        private string tMOceanTariffServiceField;

        private string tMPortOfLoadingField;

        private string tMPortOfDischargeField;

        private string tMRoutedViaField;

        private string tMServiceAttributeField;

        private string tMFreightCostCurrencyField;

        private string tMFreightChargeCurrencyField;

        private string bOLNumberField;

        private string bOLPrintedField;

        private string st_StorerKeyField;

        private string st_CompanyField;

        private string st_Address1Field;

        private string st_Address2Field;

        private string st_Address3Field;

        private string st_Address4Field;

        private string st_CityField;

        private string st_StateField;

        private string st_ZipField;

        private string st_CountryField;

        private string st_PhoneField;

        private string accountingEntityField;

        private string bODApplicationAreaField;

        private string splitShipmentFinalShipmentField;

        private string splitShipmentIndicatorField;

        private string splitShipmentOriginalOrderKeyField;

        private string suspendedIndicatorField;

        private string trailerNumberField;

        private string referenceLIDField;

        private string ext_udf_str1Field;

        private ShipmentConfirmationShipmentOrderHeaderCustomerAccountingEntity customerAccountingEntityField;

        private ShipmentConfirmationShipmentOrderHeaderReturnAccountingEntity returnAccountingEntityField;

        private ShipmentConfirmationShipmentOrderHeaderLoad loadField;

        private ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetail[] shipmentOrderDetailField;

        private ShipmentConfirmationShipmentOrderHeaderPickDetail[] pickDetailField;

        /// <remarks/>
        public string OrderKey
        {
            get
            {
                return this.orderKeyField;
            }
            set
            {
                this.orderKeyField = value;
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
        public string ExternOrderKey
        {
            get
            {
                return this.externOrderKeyField;
            }
            set
            {
                this.externOrderKeyField = value;
            }
        }

        /// <remarks/>
        public string ExternalOrderKey2
        {
            get
            {
                return this.externalOrderKey2Field;
            }
            set
            {
                this.externalOrderKey2Field = value;
            }
        }

        /// <remarks/>
        public string OrderDate
        {
            get
            {
                return this.orderDateField;
            }
            set
            {
                this.orderDateField = value;
            }
        }

        /// <remarks/>
        public string DeliveryDate
        {
            get
            {
                return this.deliveryDateField;
            }
            set
            {
                this.deliveryDateField = value;
            }
        }

        /// <remarks/>
        public string Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        public string ConsigneeKey
        {
            get
            {
                return this.consigneeKeyField;
            }
            set
            {
                this.consigneeKeyField = value;
            }
        }

        /// <remarks/>
        public string C_Contact1
        {
            get
            {
                return this.c_Contact1Field;
            }
            set
            {
                this.c_Contact1Field = value;
            }
        }

        /// <remarks/>
        public string C_Contact2
        {
            get
            {
                return this.c_Contact2Field;
            }
            set
            {
                this.c_Contact2Field = value;
            }
        }

        /// <remarks/>
        public string C_Company
        {
            get
            {
                return this.c_CompanyField;
            }
            set
            {
                this.c_CompanyField = value;
            }
        }

        /// <remarks/>
        public string C_Address1
        {
            get
            {
                return this.c_Address1Field;
            }
            set
            {
                this.c_Address1Field = value;
            }
        }

        /// <remarks/>
        public string C_Address2
        {
            get
            {
                return this.c_Address2Field;
            }
            set
            {
                this.c_Address2Field = value;
            }
        }

        /// <remarks/>
        public string C_Address3
        {
            get
            {
                return this.c_Address3Field;
            }
            set
            {
                this.c_Address3Field = value;
            }
        }

        /// <remarks/>
        public string C_Address4
        {
            get
            {
                return this.c_Address4Field;
            }
            set
            {
                this.c_Address4Field = value;
            }
        }

        /// <remarks/>
        public string C_Address5
        {
            get
            {
                return this.c_Address5Field;
            }
            set
            {
                this.c_Address5Field = value;
            }
        }

        /// <remarks/>
        public string C_Address6
        {
            get
            {
                return this.c_Address6Field;
            }
            set
            {
                this.c_Address6Field = value;
            }
        }

        /// <remarks/>
        public string C_City
        {
            get
            {
                return this.c_CityField;
            }
            set
            {
                this.c_CityField = value;
            }
        }

        /// <remarks/>
        public string C_State
        {
            get
            {
                return this.c_StateField;
            }
            set
            {
                this.c_StateField = value;
            }
        }

        /// <remarks/>
        public string C_Zip
        {
            get
            {
                return this.c_ZipField;
            }
            set
            {
                this.c_ZipField = value;
            }
        }

        /// <remarks/>
        public string C_Country
        {
            get
            {
                return this.c_CountryField;
            }
            set
            {
                this.c_CountryField = value;
            }
        }

        /// <remarks/>
        public string C_ISOCntryCode
        {
            get
            {
                return this.c_ISOCntryCodeField;
            }
            set
            {
                this.c_ISOCntryCodeField = value;
            }
        }

        /// <remarks/>
        public string C_Phone1
        {
            get
            {
                return this.c_Phone1Field;
            }
            set
            {
                this.c_Phone1Field = value;
            }
        }

        /// <remarks/>
        public string C_Phone2
        {
            get
            {
                return this.c_Phone2Field;
            }
            set
            {
                this.c_Phone2Field = value;
            }
        }

        /// <remarks/>
        public string C_Fax1
        {
            get
            {
                return this.c_Fax1Field;
            }
            set
            {
                this.c_Fax1Field = value;
            }
        }

        /// <remarks/>
        public string C_Fax2
        {
            get
            {
                return this.c_Fax2Field;
            }
            set
            {
                this.c_Fax2Field = value;
            }
        }

        /// <remarks/>
        public string C_Email1
        {
            get
            {
                return this.c_Email1Field;
            }
            set
            {
                this.c_Email1Field = value;
            }
        }

        /// <remarks/>
        public string C_Email2
        {
            get
            {
                return this.c_Email2Field;
            }
            set
            {
                this.c_Email2Field = value;
            }
        }

        /// <remarks/>
        public string C_Vat
        {
            get
            {
                return this.c_VatField;
            }
            set
            {
                this.c_VatField = value;
            }
        }

        /// <remarks/>
        public string BuyerPO
        {
            get
            {
                return this.buyerPOField;
            }
            set
            {
                this.buyerPOField = value;
            }
        }

        /// <remarks/>
        public string ReturnToParty
        {
            get
            {
                return this.returnToPartyField;
            }
            set
            {
                this.returnToPartyField = value;
            }
        }

        /// <remarks/>
        public string BillToKey
        {
            get
            {
                return this.billToKeyField;
            }
            set
            {
                this.billToKeyField = value;
            }
        }

        /// <remarks/>
        public string B_Contact1
        {
            get
            {
                return this.b_Contact1Field;
            }
            set
            {
                this.b_Contact1Field = value;
            }
        }

        /// <remarks/>
        public string B_Contact2
        {
            get
            {
                return this.b_Contact2Field;
            }
            set
            {
                this.b_Contact2Field = value;
            }
        }

        /// <remarks/>
        public string B_Company
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
        public string B_Address1
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
        public string B_Address2
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
        public string B_Address3
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
        public string B_Address4
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
        public string B_Address5
        {
            get
            {
                return this.b_Address5Field;
            }
            set
            {
                this.b_Address5Field = value;
            }
        }

        /// <remarks/>
        public string B_Address6
        {
            get
            {
                return this.b_Address6Field;
            }
            set
            {
                this.b_Address6Field = value;
            }
        }

        /// <remarks/>
        public string B_City
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
        public string B_State
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
        public string B_Zip
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
        public string B_Country
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
        public string B_ISOCntryCode
        {
            get
            {
                return this.b_ISOCntryCodeField;
            }
            set
            {
                this.b_ISOCntryCodeField = value;
            }
        }

        /// <remarks/>
        public string B_Phone1
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
        public string B_Phone2
        {
            get
            {
                return this.b_Phone2Field;
            }
            set
            {
                this.b_Phone2Field = value;
            }
        }

        /// <remarks/>
        public string B_Fax1
        {
            get
            {
                return this.b_Fax1Field;
            }
            set
            {
                this.b_Fax1Field = value;
            }
        }

        /// <remarks/>
        public string B_Fax2
        {
            get
            {
                return this.b_Fax2Field;
            }
            set
            {
                this.b_Fax2Field = value;
            }
        }

        /// <remarks/>
        public string B_VAT
        {
            get
            {
                return this.b_VATField;
            }
            set
            {
                this.b_VATField = value;
            }
        }

        /// <remarks/>
        public string IncoTerm
        {
            get
            {
                return this.incoTermField;
            }
            set
            {
                this.incoTermField = value;
            }
        }

        /// <remarks/>
        public string PmtTerm
        {
            get
            {
                return this.pmtTermField;
            }
            set
            {
                this.pmtTermField = value;
            }
        }

        /// <remarks/>
        public string Door
        {
            get
            {
                return this.doorField;
            }
            set
            {
                this.doorField = value;
            }
        }

        /// <remarks/>
        public string Route
        {
            get
            {
                return this.routeField;
            }
            set
            {
                this.routeField = value;
            }
        }

        /// <remarks/>
        public string Stop
        {
            get
            {
                return this.stopField;
            }
            set
            {
                this.stopField = value;
            }
        }

        /// <remarks/>
        public decimal OpenQty
        {
            get
            {
                return this.openQtyField;
            }
            set
            {
                this.openQtyField = value;
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
        public string DischargePlace
        {
            get
            {
                return this.dischargePlaceField;
            }
            set
            {
                this.dischargePlaceField = value;
            }
        }

        /// <remarks/>
        public string DeliveryPlace
        {
            get
            {
                return this.deliveryPlaceField;
            }
            set
            {
                this.deliveryPlaceField = value;
            }
        }

        /// <remarks/>
        public string IntermodalVehicle
        {
            get
            {
                return this.intermodalVehicleField;
            }
            set
            {
                this.intermodalVehicleField = value;
            }
        }

        /// <remarks/>
        public string CountryOfOrigin
        {
            get
            {
                return this.countryOfOriginField;
            }
            set
            {
                this.countryOfOriginField = value;
            }
        }

        /// <remarks/>
        public string UpdateSource
        {
            get
            {
                return this.updateSourceField;
            }
            set
            {
                this.updateSourceField = value;
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
        public string OrderGroup
        {
            get
            {
                return this.orderGroupField;
            }
            set
            {
                this.orderGroupField = value;
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
        public decimal Item_Number
        {
            get
            {
                return this.item_NumberField;
            }
            set
            {
                this.item_NumberField = value;
            }
        }

        /// <remarks/>
        public string ContainerType
        {
            get
            {
                return this.containerTypeField;
            }
            set
            {
                this.containerTypeField = value;
            }
        }

        /// <remarks/>
        public string ContainerQty
        {
            get
            {
                return this.containerQtyField;
            }
            set
            {
                this.containerQtyField = value;
            }
        }

        /// <remarks/>
        public string BilledContainerQty
        {
            get
            {
                return this.billedContainerQtyField;
            }
            set
            {
                this.billedContainerQtyField = value;
            }
        }

        /// <remarks/>
        public string ChepPalletIndicator
        {
            get
            {
                return this.chepPalletIndicatorField;
            }
            set
            {
                this.chepPalletIndicatorField = value;
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
        public string TransportationService
        {
            get
            {
                return this.transportationServiceField;
            }
            set
            {
                this.transportationServiceField = value;
            }
        }

        /// <remarks/>
        public string SUsr1
        {
            get
            {
                return this.sUsr1Field;
            }
            set
            {
                this.sUsr1Field = value;
            }
        }

        /// <remarks/>
        public string SUsr2
        {
            get
            {
                return this.sUsr2Field;
            }
            set
            {
                this.sUsr2Field = value;
            }
        }

        /// <remarks/>
        public string SUsr3
        {
            get
            {
                return this.sUsr3Field;
            }
            set
            {
                this.sUsr3Field = value;
            }
        }

        /// <remarks/>
        public string SUsr4
        {
            get
            {
                return this.sUsr4Field;
            }
            set
            {
                this.sUsr4Field = value;
            }
        }

        /// <remarks/>
        public string SUsr5
        {
            get
            {
                return this.sUsr5Field;
            }
            set
            {
                this.sUsr5Field = value;
            }
        }

        /// <remarks/>
        public string Notes2
        {
            get
            {
                return this.notes2Field;
            }
            set
            {
                this.notes2Field = value;
            }
        }

        /// <remarks/>
        public string OHType
        {
            get
            {
                return this.oHTypeField;
            }
            set
            {
                this.oHTypeField = value;
            }
        }

        /// <remarks/>
        public string LoadID
        {
            get
            {
                return this.loadIDField;
            }
            set
            {
                this.loadIDField = value;
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
        public string AddWho
        {
            get
            {
                return this.addWhoField;
            }
            set
            {
                this.addWhoField = value;
            }
        }

        /// <remarks/>
        public string EditWho
        {
            get
            {
                return this.editWhoField;
            }
            set
            {
                this.editWhoField = value;
            }
        }

        /// <remarks/>
        public string Forte_Flag
        {
            get
            {
                return this.forte_FlagField;
            }
            set
            {
                this.forte_FlagField = value;
            }
        }

        /// <remarks/>
        public string Stage
        {
            get
            {
                return this.stageField;
            }
            set
            {
                this.stageField = value;
            }
        }

        /// <remarks/>
        public string Dc_Id
        {
            get
            {
                return this.dc_IdField;
            }
            set
            {
                this.dc_IdField = value;
            }
        }

        /// <remarks/>
        public string Whse_Id
        {
            get
            {
                return this.whse_IdField;
            }
            set
            {
                this.whse_IdField = value;
            }
        }

        /// <remarks/>
        public string Split_Orders
        {
            get
            {
                return this.split_OrdersField;
            }
            set
            {
                this.split_OrdersField = value;
            }
        }

        /// <remarks/>
        public string Appt_Status
        {
            get
            {
                return this.appt_StatusField;
            }
            set
            {
                this.appt_StatusField = value;
            }
        }

        /// <remarks/>
        public string Shiptogether
        {
            get
            {
                return this.shiptogetherField;
            }
            set
            {
                this.shiptogetherField = value;
            }
        }

        /// <remarks/>
        public string DeliveryDate2
        {
            get
            {
                return this.deliveryDate2Field;
            }
            set
            {
                this.deliveryDate2Field = value;
            }
        }

        /// <remarks/>
        public string RequestedShipDate
        {
            get
            {
                return this.requestedShipDateField;
            }
            set
            {
                this.requestedShipDateField = value;
            }
        }

        /// <remarks/>
        public string ActualShipDate
        {
            get
            {
                return this.actualShipDateField;
            }
            set
            {
                this.actualShipDateField = value;
            }
        }

        /// <remarks/>
        public string Deliver_Date
        {
            get
            {
                return this.deliver_DateField;
            }
            set
            {
                this.deliver_DateField = value;
            }
        }

        /// <remarks/>
        public decimal OrderValue
        {
            get
            {
                return this.orderValueField;
            }
            set
            {
                this.orderValueField = value;
            }
        }

        /// <remarks/>
        public string ExternalLoadId
        {
            get
            {
                return this.externalLoadIdField;
            }
            set
            {
                this.externalLoadIdField = value;
            }
        }

        /// <remarks/>
        public string SortationLocation
        {
            get
            {
                return this.sortationLocationField;
            }
            set
            {
                this.sortationLocationField = value;
            }
        }

        /// <remarks/>
        public string BatchFlag
        {
            get
            {
                return this.batchFlagField;
            }
            set
            {
                this.batchFlagField = value;
            }
        }

        /// <remarks/>
        public string BulkCartonGroup
        {
            get
            {
                return this.bulkCartonGroupField;
            }
            set
            {
                this.bulkCartonGroupField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNum
        {
            get
            {
                return this.referenceNumField;
            }
            set
            {
                this.referenceNumField = value;
            }
        }

        /// <remarks/>
        public string DestinationNestId
        {
            get
            {
                return this.destinationNestIdField;
            }
            set
            {
                this.destinationNestIdField = value;
            }
        }

        /// <remarks/>
        public string IntransitKey
        {
            get
            {
                return this.intransitKeyField;
            }
            set
            {
                this.intransitKeyField = value;
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
        public string LabelName
        {
            get
            {
                return this.labelNameField;
            }
            set
            {
                this.labelNameField = value;
            }
        }

        /// <remarks/>
        public string WhseId
        {
            get
            {
                return this.whseIdField;
            }
            set
            {
                this.whseIdField = value;
            }
        }

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
        public string RfidFlag
        {
            get
            {
                return this.rfidFlagField;
            }
            set
            {
                this.rfidFlagField = value;
            }
        }

        /// <remarks/>
        public string CountryDestination
        {
            get
            {
                return this.countryDestinationField;
            }
            set
            {
                this.countryDestinationField = value;
            }
        }

        /// <remarks/>
        public string CarrierCode
        {
            get
            {
                return this.carrierCodeField;
            }
            set
            {
                this.carrierCodeField = value;
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
        public string CarrierPhone
        {
            get
            {
                return this.carrierPhoneField;
            }
            set
            {
                this.carrierPhoneField = value;
            }
        }

        /// <remarks/>
        public string ProNumber
        {
            get
            {
                return this.proNumberField;
            }
            set
            {
                this.proNumberField = value;
            }
        }

        /// <remarks/>
        public string TradingPartner
        {
            get
            {
                return this.tradingPartnerField;
            }
            set
            {
                this.tradingPartnerField = value;
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
        public string FreightChargeAmount
        {
            get
            {
                return this.freightChargeAmountField;
            }
            set
            {
                this.freightChargeAmountField = value;
            }
        }

        /// <remarks/>
        public string FreightCostAmount
        {
            get
            {
                return this.freightCostAmountField;
            }
            set
            {
                this.freightCostAmountField = value;
            }
        }

        /// <remarks/>
        public string FreightChargeBaseAmount
        {
            get
            {
                return this.freightChargeBaseAmountField;
            }
            set
            {
                this.freightChargeBaseAmountField = value;
            }
        }

        /// <remarks/>
        public string FreightCostBaseAmount
        {
            get
            {
                return this.freightCostBaseAmountField;
            }
            set
            {
                this.freightCostBaseAmountField = value;
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
        public string ScheduledShipDate
        {
            get
            {
                return this.scheduledShipDateField;
            }
            set
            {
                this.scheduledShipDateField = value;
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
        public string PromisedDelvDate
        {
            get
            {
                return this.promisedDelvDateField;
            }
            set
            {
                this.promisedDelvDateField = value;
            }
        }

        /// <remarks/>
        public string PlannedDelvDate
        {
            get
            {
                return this.plannedDelvDateField;
            }
            set
            {
                this.plannedDelvDateField = value;
            }
        }

        /// <remarks/>
        public string ScheduledDelvDate
        {
            get
            {
                return this.scheduledDelvDateField;
            }
            set
            {
                this.scheduledDelvDateField = value;
            }
        }

        /// <remarks/>
        public string ActualDelvDate
        {
            get
            {
                return this.actualDelvDateField;
            }
            set
            {
                this.actualDelvDateField = value;
            }
        }

        /// <remarks/>
        public string CarrierRouteDocument
        {
            get
            {
                return this.carrierRouteDocumentField;
            }
            set
            {
                this.carrierRouteDocumentField = value;
            }
        }

        /// <remarks/>
        public string CarrierRouteAccountingEntity
        {
            get
            {
                return this.carrierRouteAccountingEntityField;
            }
            set
            {
                this.carrierRouteAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public string CarrierRouteLocation
        {
            get
            {
                return this.carrierRouteLocationField;
            }
            set
            {
                this.carrierRouteLocationField = value;
            }
        }

        /// <remarks/>
        public string CarrierRouteVersion
        {
            get
            {
                return this.carrierRouteVersionField;
            }
            set
            {
                this.carrierRouteVersionField = value;
            }
        }

        /// <remarks/>
        public string CarrierRouteStatus
        {
            get
            {
                return this.carrierRouteStatusField;
            }
            set
            {
                this.carrierRouteStatusField = value;
            }
        }

        /// <remarks/>
        public string TMHouseAirWayBillNumber
        {
            get
            {
                return this.tMHouseAirWayBillNumberField;
            }
            set
            {
                this.tMHouseAirWayBillNumberField = value;
            }
        }

        /// <remarks/>
        public string TMMasterAirWayBillNumber
        {
            get
            {
                return this.tMMasterAirWayBillNumberField;
            }
            set
            {
                this.tMMasterAirWayBillNumberField = value;
            }
        }

        /// <remarks/>
        public string TMBookingNumber
        {
            get
            {
                return this.tMBookingNumberField;
            }
            set
            {
                this.tMBookingNumberField = value;
            }
        }

        /// <remarks/>
        public string TMHouseOceanBOLNumber
        {
            get
            {
                return this.tMHouseOceanBOLNumberField;
            }
            set
            {
                this.tMHouseOceanBOLNumberField = value;
            }
        }

        /// <remarks/>
        public string TMMasterOceanBOLNumber
        {
            get
            {
                return this.tMMasterOceanBOLNumberField;
            }
            set
            {
                this.tMMasterOceanBOLNumberField = value;
            }
        }

        /// <remarks/>
        public string TMEquipmentNumber
        {
            get
            {
                return this.tMEquipmentNumberField;
            }
            set
            {
                this.tMEquipmentNumberField = value;
            }
        }

        /// <remarks/>
        public string TMSealNumber
        {
            get
            {
                return this.tMSealNumberField;
            }
            set
            {
                this.tMSealNumberField = value;
            }
        }

        /// <remarks/>
        public string TMLicensePlateNumber
        {
            get
            {
                return this.tMLicensePlateNumberField;
            }
            set
            {
                this.tMLicensePlateNumberField = value;
            }
        }

        /// <remarks/>
        public string TMEquipmentType
        {
            get
            {
                return this.tMEquipmentTypeField;
            }
            set
            {
                this.tMEquipmentTypeField = value;
            }
        }

        /// <remarks/>
        public string TMEquipmentLength
        {
            get
            {
                return this.tMEquipmentLengthField;
            }
            set
            {
                this.tMEquipmentLengthField = value;
            }
        }

        /// <remarks/>
        public string TMEquipmentAttribute
        {
            get
            {
                return this.tMEquipmentAttributeField;
            }
            set
            {
                this.tMEquipmentAttributeField = value;
            }
        }

        /// <remarks/>
        public string TMAirServiceLevel
        {
            get
            {
                return this.tMAirServiceLevelField;
            }
            set
            {
                this.tMAirServiceLevelField = value;
            }
        }

        /// <remarks/>
        public string TMOceanServiceLevel
        {
            get
            {
                return this.tMOceanServiceLevelField;
            }
            set
            {
                this.tMOceanServiceLevelField = value;
            }
        }

        /// <remarks/>
        public string TMOceanTariffService
        {
            get
            {
                return this.tMOceanTariffServiceField;
            }
            set
            {
                this.tMOceanTariffServiceField = value;
            }
        }

        /// <remarks/>
        public string TMPortOfLoading
        {
            get
            {
                return this.tMPortOfLoadingField;
            }
            set
            {
                this.tMPortOfLoadingField = value;
            }
        }

        /// <remarks/>
        public string TMPortOfDischarge
        {
            get
            {
                return this.tMPortOfDischargeField;
            }
            set
            {
                this.tMPortOfDischargeField = value;
            }
        }

        /// <remarks/>
        public string TMRoutedVia
        {
            get
            {
                return this.tMRoutedViaField;
            }
            set
            {
                this.tMRoutedViaField = value;
            }
        }

        /// <remarks/>
        public string TMServiceAttribute
        {
            get
            {
                return this.tMServiceAttributeField;
            }
            set
            {
                this.tMServiceAttributeField = value;
            }
        }

        /// <remarks/>
        public string TMFreightCostCurrency
        {
            get
            {
                return this.tMFreightCostCurrencyField;
            }
            set
            {
                this.tMFreightCostCurrencyField = value;
            }
        }

        /// <remarks/>
        public string TMFreightChargeCurrency
        {
            get
            {
                return this.tMFreightChargeCurrencyField;
            }
            set
            {
                this.tMFreightChargeCurrencyField = value;
            }
        }

        /// <remarks/>
        public string BOLNumber
        {
            get
            {
                return this.bOLNumberField;
            }
            set
            {
                this.bOLNumberField = value;
            }
        }

        /// <remarks/>
        public string BOLPrinted
        {
            get
            {
                return this.bOLPrintedField;
            }
            set
            {
                this.bOLPrintedField = value;
            }
        }

        /// <remarks/>
        public string st_StorerKey
        {
            get
            {
                return this.st_StorerKeyField;
            }
            set
            {
                this.st_StorerKeyField = value;
            }
        }

        /// <remarks/>
        public string st_Company
        {
            get
            {
                return this.st_CompanyField;
            }
            set
            {
                this.st_CompanyField = value;
            }
        }

        /// <remarks/>
        public string st_Address1
        {
            get
            {
                return this.st_Address1Field;
            }
            set
            {
                this.st_Address1Field = value;
            }
        }

        /// <remarks/>
        public string st_Address2
        {
            get
            {
                return this.st_Address2Field;
            }
            set
            {
                this.st_Address2Field = value;
            }
        }

        /// <remarks/>
        public string st_Address3
        {
            get
            {
                return this.st_Address3Field;
            }
            set
            {
                this.st_Address3Field = value;
            }
        }

        /// <remarks/>
        public string st_Address4
        {
            get
            {
                return this.st_Address4Field;
            }
            set
            {
                this.st_Address4Field = value;
            }
        }

        /// <remarks/>
        public string st_City
        {
            get
            {
                return this.st_CityField;
            }
            set
            {
                this.st_CityField = value;
            }
        }

        /// <remarks/>
        public string st_State
        {
            get
            {
                return this.st_StateField;
            }
            set
            {
                this.st_StateField = value;
            }
        }

        /// <remarks/>
        public string st_Zip
        {
            get
            {
                return this.st_ZipField;
            }
            set
            {
                this.st_ZipField = value;
            }
        }

        /// <remarks/>
        public string st_Country
        {
            get
            {
                return this.st_CountryField;
            }
            set
            {
                this.st_CountryField = value;
            }
        }

        /// <remarks/>
        public string st_Phone
        {
            get
            {
                return this.st_PhoneField;
            }
            set
            {
                this.st_PhoneField = value;
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
        public string BODApplicationArea
        {
            get
            {
                return this.bODApplicationAreaField;
            }
            set
            {
                this.bODApplicationAreaField = value;
            }
        }

        /// <remarks/>
        public string SplitShipmentFinalShipment
        {
            get
            {
                return this.splitShipmentFinalShipmentField;
            }
            set
            {
                this.splitShipmentFinalShipmentField = value;
            }
        }

        /// <remarks/>
        public string SplitShipmentIndicator
        {
            get
            {
                return this.splitShipmentIndicatorField;
            }
            set
            {
                this.splitShipmentIndicatorField = value;
            }
        }

        /// <remarks/>
        public string SplitShipmentOriginalOrderKey
        {
            get
            {
                return this.splitShipmentOriginalOrderKeyField;
            }
            set
            {
                this.splitShipmentOriginalOrderKeyField = value;
            }
        }

        /// <remarks/>
        public string SuspendedIndicator
        {
            get
            {
                return this.suspendedIndicatorField;
            }
            set
            {
                this.suspendedIndicatorField = value;
            }
        }

        /// <remarks/>
        public string TrailerNumber
        {
            get
            {
                return this.trailerNumberField;
            }
            set
            {
                this.trailerNumberField = value;
            }
        }

        /// <remarks/>
        public string ReferenceLID
        {
            get
            {
                return this.referenceLIDField;
            }
            set
            {
                this.referenceLIDField = value;
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
        public ShipmentConfirmationShipmentOrderHeaderCustomerAccountingEntity CustomerAccountingEntity
        {
            get
            {
                return this.customerAccountingEntityField;
            }
            set
            {
                this.customerAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public ShipmentConfirmationShipmentOrderHeaderReturnAccountingEntity ReturnAccountingEntity
        {
            get
            {
                return this.returnAccountingEntityField;
            }
            set
            {
                this.returnAccountingEntityField = value;
            }
        }

        /// <remarks/>
        public ShipmentConfirmationShipmentOrderHeaderLoad Load
        {
            get
            {
                return this.loadField;
            }
            set
            {
                this.loadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ShipmentOrderDetail")]
        public ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetail[] ShipmentOrderDetail
        {
            get
            {
                return this.shipmentOrderDetailField;
            }
            set
            {
                this.shipmentOrderDetailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PickDetail")]
        public ShipmentConfirmationShipmentOrderHeaderPickDetail[] PickDetail
        {
            get
            {
                return this.pickDetailField;
            }
            set
            {
                this.pickDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationShipmentOrderHeaderCustomerAccountingEntity
    {

        private string accountingEntityField;

        private string parentField;

        private string defaultTransportationServiceField;

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
        public string Parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }

        /// <remarks/>
        public string DefaultTransportationService
        {
            get
            {
                return this.defaultTransportationServiceField;
            }
            set
            {
                this.defaultTransportationServiceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationShipmentOrderHeaderReturnAccountingEntity
    {

        private string accountingEntityField;

        private string parentField;

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
        public string Parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationShipmentOrderHeaderLoad
    {

        private string loadCountField;

        /// <remarks/>
        public string LoadCount
        {
            get
            {
                return this.loadCountField;
            }
            set
            {
                this.loadCountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetail
    {

        private string orderKeyField;

        private string orderLineNumberField;

        private ushort orderDetailSysIDField;

        private string externOrderKeyField;

        private string externLineNoField;

        private string skuField;

        private string tariffKeyField;

        private string storerKeyField;

        private string manufacturerSkuField;

        private string retailSkuField;

        private string altSkuField;

        private decimal originalQtyField;

        private decimal openQtyField;

        private decimal shippedQtyField;

        private decimal adjustedQtyField;

        private decimal qtyPreallocatedField;

        private decimal qtyAllocatedField;

        private decimal qtyPickedField;

        private string uOMField;

        private string packKeyField;

        private string pickCodeField;

        private string componentReferenceField;

        private string cartonGroupField;

        private string lotField;

        private string idField;

        private string facilityField;

        private string statusField;

        private string unitPriceField;

        private string tax01Field;

        private string tax02Field;

        private string extendedPriceField;

        private string updateSourceField;

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

        private string effectiveDateField;

        private string sUsr1Field;

        private string sUsr2Field;

        private string sUsr3Field;

        private string sUsr4Field;

        private string sUsr5Field;

        private string notesField;

        private string workOrderKeyField;

        private string addDateField;

        private string editDateField;

        private string addWhoField;

        private string editWhoField;

        private string forte_FlagField;

        private string allocateStrategyKeyField;

        private string preAllocateStrategyKeyField;

        private string allocateStrategyTypeField;

        private string skuRotationField;

        private string shelfLifeField;

        private string rotationField;

        private string pallet_IdField;

        private string sub_FlagField;

        private string originalSkuField;

        private decimal runInQTYField;

        private decimal runOutQTYField;

        private string runInUOMField;

        private string runOutUOMField;

        private string product_WeightField;

        private string product_CubeField;

        private decimal origCaseQtyField;

        private decimal origPalletQtyField;

        private string okToSubstituteField;

        private string isSubstituteField;

        private string originalLineNumberField;

        private string shipGroup01Field;

        private string shipGroup02Field;

        private string shipGroup03Field;

        private string actualShipDateField;

        private string interModalVehicleField;

        private string pickingInstructionsField;

        private string cartonBreakField;

        private string cartonQtyBreakField;

        private decimal qtyInTransitField;

        private string serialKeyField;

        private string oppRequestField;

        private string whseIdField;

        private string wPReleasedField;

        private string externAllocSequenceField;

        private string sourceVersionField;

        private string referenceTypeField;

        private string referenceDocumentField;

        private string referenceLocationField;

        private string referenceLineField;

        private string referenceAccountingEntityField;

        private decimal fulfillQtyField;

        private string lineTypeField;

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

        private string transportationServiceField;

        private decimal stdGrossWgtField;

        private decimal stdNetWgtField;

        private decimal stdCubeField;

        private string hazMatCodesKeyField;

        private string descrField;

        private string freightClassField;

        private string oCDFlagField;

        private string oCDLabel1Field;

        private string oCDLabel2Field;

        private string nonStockedIndicatorField;

        private string accountingEntityField;

        private string fillQtyUOMField;

        private string itemIDField;

        private string itrnKeyField;

        private string itrnLottable09Field;

        private string itrnLottable10Field;

        private string holdCodeField;

        private decimal pDQtyField;

        private decimal pDQtyRejectedField;

        private string pDRejectedReasonField;

        private string idRequiredField;

        private string backflushIndicatorField;

        private string stageLocField;

        private string nMFCClassField;

        private string buyerPOField;

        private ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailSkuFields skuFieldsField;

        private ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailPickDetailCountSequence pickDetailCountSequenceField;

        private ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailLotAttribute lotAttributeField;

        /// <remarks/>
        public string OrderKey
        {
            get
            {
                return this.orderKeyField;
            }
            set
            {
                this.orderKeyField = value;
            }
        }

        /// <remarks/>
        public string OrderLineNumber
        {
            get
            {
                return this.orderLineNumberField;
            }
            set
            {
                this.orderLineNumberField = value;
            }
        }

        /// <remarks/>
        public ushort OrderDetailSysID
        {
            get
            {
                return this.orderDetailSysIDField;
            }
            set
            {
                this.orderDetailSysIDField = value;
            }
        }

        /// <remarks/>
        public string ExternOrderKey
        {
            get
            {
                return this.externOrderKeyField;
            }
            set
            {
                this.externOrderKeyField = value;
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
        public string TariffKey
        {
            get
            {
                return this.tariffKeyField;
            }
            set
            {
                this.tariffKeyField = value;
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
        public string ManufacturerSku
        {
            get
            {
                return this.manufacturerSkuField;
            }
            set
            {
                this.manufacturerSkuField = value;
            }
        }

        /// <remarks/>
        public string RetailSku
        {
            get
            {
                return this.retailSkuField;
            }
            set
            {
                this.retailSkuField = value;
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
        public decimal OriginalQty
        {
            get
            {
                return this.originalQtyField;
            }
            set
            {
                this.originalQtyField = value;
            }
        }

        /// <remarks/>
        public decimal OpenQty
        {
            get
            {
                return this.openQtyField;
            }
            set
            {
                this.openQtyField = value;
            }
        }

        /// <remarks/>
        public decimal ShippedQty
        {
            get
            {
                return this.shippedQtyField;
            }
            set
            {
                this.shippedQtyField = value;
            }
        }

        /// <remarks/>
        public decimal AdjustedQty
        {
            get
            {
                return this.adjustedQtyField;
            }
            set
            {
                this.adjustedQtyField = value;
            }
        }

        /// <remarks/>
        public decimal QtyPreallocated
        {
            get
            {
                return this.qtyPreallocatedField;
            }
            set
            {
                this.qtyPreallocatedField = value;
            }
        }

        /// <remarks/>
        public decimal QtyAllocated
        {
            get
            {
                return this.qtyAllocatedField;
            }
            set
            {
                this.qtyAllocatedField = value;
            }
        }

        /// <remarks/>
        public decimal QtyPicked
        {
            get
            {
                return this.qtyPickedField;
            }
            set
            {
                this.qtyPickedField = value;
            }
        }

        /// <remarks/>
        public string UOM
        {
            get
            {
                return this.uOMField;
            }
            set
            {
                this.uOMField = value;
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
        public string PickCode
        {
            get
            {
                return this.pickCodeField;
            }
            set
            {
                this.pickCodeField = value;
            }
        }

        /// <remarks/>
        public string ComponentReference
        {
            get
            {
                return this.componentReferenceField;
            }
            set
            {
                this.componentReferenceField = value;
            }
        }

        /// <remarks/>
        public string CartonGroup
        {
            get
            {
                return this.cartonGroupField;
            }
            set
            {
                this.cartonGroupField = value;
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
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

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
        public string UnitPrice
        {
            get
            {
                return this.unitPriceField;
            }
            set
            {
                this.unitPriceField = value;
            }
        }

        /// <remarks/>
        public string Tax01
        {
            get
            {
                return this.tax01Field;
            }
            set
            {
                this.tax01Field = value;
            }
        }

        /// <remarks/>
        public string Tax02
        {
            get
            {
                return this.tax02Field;
            }
            set
            {
                this.tax02Field = value;
            }
        }

        /// <remarks/>
        public string ExtendedPrice
        {
            get
            {
                return this.extendedPriceField;
            }
            set
            {
                this.extendedPriceField = value;
            }
        }

        /// <remarks/>
        public string UpdateSource
        {
            get
            {
                return this.updateSourceField;
            }
            set
            {
                this.updateSourceField = value;
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
        public string SUsr1
        {
            get
            {
                return this.sUsr1Field;
            }
            set
            {
                this.sUsr1Field = value;
            }
        }

        /// <remarks/>
        public string SUsr2
        {
            get
            {
                return this.sUsr2Field;
            }
            set
            {
                this.sUsr2Field = value;
            }
        }

        /// <remarks/>
        public string SUsr3
        {
            get
            {
                return this.sUsr3Field;
            }
            set
            {
                this.sUsr3Field = value;
            }
        }

        /// <remarks/>
        public string SUsr4
        {
            get
            {
                return this.sUsr4Field;
            }
            set
            {
                this.sUsr4Field = value;
            }
        }

        /// <remarks/>
        public string SUsr5
        {
            get
            {
                return this.sUsr5Field;
            }
            set
            {
                this.sUsr5Field = value;
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
        public string WorkOrderKey
        {
            get
            {
                return this.workOrderKeyField;
            }
            set
            {
                this.workOrderKeyField = value;
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
        public string AddWho
        {
            get
            {
                return this.addWhoField;
            }
            set
            {
                this.addWhoField = value;
            }
        }

        /// <remarks/>
        public string EditWho
        {
            get
            {
                return this.editWhoField;
            }
            set
            {
                this.editWhoField = value;
            }
        }

        /// <remarks/>
        public string Forte_Flag
        {
            get
            {
                return this.forte_FlagField;
            }
            set
            {
                this.forte_FlagField = value;
            }
        }

        /// <remarks/>
        public string AllocateStrategyKey
        {
            get
            {
                return this.allocateStrategyKeyField;
            }
            set
            {
                this.allocateStrategyKeyField = value;
            }
        }

        /// <remarks/>
        public string PreAllocateStrategyKey
        {
            get
            {
                return this.preAllocateStrategyKeyField;
            }
            set
            {
                this.preAllocateStrategyKeyField = value;
            }
        }

        /// <remarks/>
        public string AllocateStrategyType
        {
            get
            {
                return this.allocateStrategyTypeField;
            }
            set
            {
                this.allocateStrategyTypeField = value;
            }
        }

        /// <remarks/>
        public string SkuRotation
        {
            get
            {
                return this.skuRotationField;
            }
            set
            {
                this.skuRotationField = value;
            }
        }

        /// <remarks/>
        public string ShelfLife
        {
            get
            {
                return this.shelfLifeField;
            }
            set
            {
                this.shelfLifeField = value;
            }
        }

        /// <remarks/>
        public string Rotation
        {
            get
            {
                return this.rotationField;
            }
            set
            {
                this.rotationField = value;
            }
        }

        /// <remarks/>
        public string Pallet_Id
        {
            get
            {
                return this.pallet_IdField;
            }
            set
            {
                this.pallet_IdField = value;
            }
        }

        /// <remarks/>
        public string Sub_Flag
        {
            get
            {
                return this.sub_FlagField;
            }
            set
            {
                this.sub_FlagField = value;
            }
        }

        /// <remarks/>
        public string OriginalSku
        {
            get
            {
                return this.originalSkuField;
            }
            set
            {
                this.originalSkuField = value;
            }
        }

        /// <remarks/>
        public decimal RunInQTY
        {
            get
            {
                return this.runInQTYField;
            }
            set
            {
                this.runInQTYField = value;
            }
        }

        /// <remarks/>
        public decimal RunOutQTY
        {
            get
            {
                return this.runOutQTYField;
            }
            set
            {
                this.runOutQTYField = value;
            }
        }

        /// <remarks/>
        public string RunInUOM
        {
            get
            {
                return this.runInUOMField;
            }
            set
            {
                this.runInUOMField = value;
            }
        }

        /// <remarks/>
        public string RunOutUOM
        {
            get
            {
                return this.runOutUOMField;
            }
            set
            {
                this.runOutUOMField = value;
            }
        }

        /// <remarks/>
        public string Product_Weight
        {
            get
            {
                return this.product_WeightField;
            }
            set
            {
                this.product_WeightField = value;
            }
        }

        /// <remarks/>
        public string Product_Cube
        {
            get
            {
                return this.product_CubeField;
            }
            set
            {
                this.product_CubeField = value;
            }
        }

        /// <remarks/>
        public decimal OrigCaseQty
        {
            get
            {
                return this.origCaseQtyField;
            }
            set
            {
                this.origCaseQtyField = value;
            }
        }

        /// <remarks/>
        public decimal OrigPalletQty
        {
            get
            {
                return this.origPalletQtyField;
            }
            set
            {
                this.origPalletQtyField = value;
            }
        }

        /// <remarks/>
        public string OkToSubstitute
        {
            get
            {
                return this.okToSubstituteField;
            }
            set
            {
                this.okToSubstituteField = value;
            }
        }

        /// <remarks/>
        public string IsSubstitute
        {
            get
            {
                return this.isSubstituteField;
            }
            set
            {
                this.isSubstituteField = value;
            }
        }

        /// <remarks/>
        public string OriginalLineNumber
        {
            get
            {
                return this.originalLineNumberField;
            }
            set
            {
                this.originalLineNumberField = value;
            }
        }

        /// <remarks/>
        public string ShipGroup01
        {
            get
            {
                return this.shipGroup01Field;
            }
            set
            {
                this.shipGroup01Field = value;
            }
        }

        /// <remarks/>
        public string ShipGroup02
        {
            get
            {
                return this.shipGroup02Field;
            }
            set
            {
                this.shipGroup02Field = value;
            }
        }

        /// <remarks/>
        public string ShipGroup03
        {
            get
            {
                return this.shipGroup03Field;
            }
            set
            {
                this.shipGroup03Field = value;
            }
        }

        /// <remarks/>
        public string ActualShipDate
        {
            get
            {
                return this.actualShipDateField;
            }
            set
            {
                this.actualShipDateField = value;
            }
        }

        /// <remarks/>
        public string InterModalVehicle
        {
            get
            {
                return this.interModalVehicleField;
            }
            set
            {
                this.interModalVehicleField = value;
            }
        }

        /// <remarks/>
        public string PickingInstructions
        {
            get
            {
                return this.pickingInstructionsField;
            }
            set
            {
                this.pickingInstructionsField = value;
            }
        }

        /// <remarks/>
        public string CartonBreak
        {
            get
            {
                return this.cartonBreakField;
            }
            set
            {
                this.cartonBreakField = value;
            }
        }

        /// <remarks/>
        public string CartonQtyBreak
        {
            get
            {
                return this.cartonQtyBreakField;
            }
            set
            {
                this.cartonQtyBreakField = value;
            }
        }

        /// <remarks/>
        public decimal QtyInTransit
        {
            get
            {
                return this.qtyInTransitField;
            }
            set
            {
                this.qtyInTransitField = value;
            }
        }

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
        public string OppRequest
        {
            get
            {
                return this.oppRequestField;
            }
            set
            {
                this.oppRequestField = value;
            }
        }

        /// <remarks/>
        public string WhseId
        {
            get
            {
                return this.whseIdField;
            }
            set
            {
                this.whseIdField = value;
            }
        }

        /// <remarks/>
        public string WPReleased
        {
            get
            {
                return this.wPReleasedField;
            }
            set
            {
                this.wPReleasedField = value;
            }
        }

        /// <remarks/>
        public string ExternAllocSequence
        {
            get
            {
                return this.externAllocSequenceField;
            }
            set
            {
                this.externAllocSequenceField = value;
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
        public decimal FulfillQty
        {
            get
            {
                return this.fulfillQtyField;
            }
            set
            {
                this.fulfillQtyField = value;
            }
        }

        /// <remarks/>
        public string LineType
        {
            get
            {
                return this.lineTypeField;
            }
            set
            {
                this.lineTypeField = value;
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
        public string TransportationService
        {
            get
            {
                return this.transportationServiceField;
            }
            set
            {
                this.transportationServiceField = value;
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
        public decimal StdNetWgt
        {
            get
            {
                return this.stdNetWgtField;
            }
            set
            {
                this.stdNetWgtField = value;
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
        public string HazMatCodesKey
        {
            get
            {
                return this.hazMatCodesKeyField;
            }
            set
            {
                this.hazMatCodesKeyField = value;
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
        public string FreightClass
        {
            get
            {
                return this.freightClassField;
            }
            set
            {
                this.freightClassField = value;
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
        public string ItemID
        {
            get
            {
                return this.itemIDField;
            }
            set
            {
                this.itemIDField = value;
            }
        }

        /// <remarks/>
        public string ItrnKey
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
        public string ItrnLottable09
        {
            get
            {
                return this.itrnLottable09Field;
            }
            set
            {
                this.itrnLottable09Field = value;
            }
        }

        /// <remarks/>
        public string ItrnLottable10
        {
            get
            {
                return this.itrnLottable10Field;
            }
            set
            {
                this.itrnLottable10Field = value;
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
        public decimal PDQty
        {
            get
            {
                return this.pDQtyField;
            }
            set
            {
                this.pDQtyField = value;
            }
        }

        /// <remarks/>
        public decimal PDQtyRejected
        {
            get
            {
                return this.pDQtyRejectedField;
            }
            set
            {
                this.pDQtyRejectedField = value;
            }
        }

        /// <remarks/>
        public string PDRejectedReason
        {
            get
            {
                return this.pDRejectedReasonField;
            }
            set
            {
                this.pDRejectedReasonField = value;
            }
        }

        /// <remarks/>
        public string IdRequired
        {
            get
            {
                return this.idRequiredField;
            }
            set
            {
                this.idRequiredField = value;
            }
        }

        /// <remarks/>
        public string BackflushIndicator
        {
            get
            {
                return this.backflushIndicatorField;
            }
            set
            {
                this.backflushIndicatorField = value;
            }
        }

        /// <remarks/>
        public string StageLoc
        {
            get
            {
                return this.stageLocField;
            }
            set
            {
                this.stageLocField = value;
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
        public string BuyerPO
        {
            get
            {
                return this.buyerPOField;
            }
            set
            {
                this.buyerPOField = value;
            }
        }

        /// <remarks/>
        public ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailSkuFields SkuFields
        {
            get
            {
                return this.skuFieldsField;
            }
            set
            {
                this.skuFieldsField = value;
            }
        }

        /// <remarks/>
        public ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailPickDetailCountSequence PickDetailCountSequence
        {
            get
            {
                return this.pickDetailCountSequenceField;
            }
            set
            {
                this.pickDetailCountSequenceField = value;
            }
        }

        /// <remarks/>
        public ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailLotAttribute LotAttribute
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
    public partial class ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailSkuFields
    {

        private string countSequenceField;

        private string packUOM3Field;

        private string palletField;

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

        /// <remarks/>
        public string Pallet
        {
            get
            {
                return this.palletField;
            }
            set
            {
                this.palletField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailPickDetailCountSequence
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
    public partial class ShipmentConfirmationShipmentOrderHeaderShipmentOrderDetailLotAttribute
    {

        private string lottable03Field;

        private string lottable04Field;

        private string lottable05Field;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationShipmentOrderHeaderPickDetail
    {

        private string pickDetailKeyField;

        private string storerKeyField;

        private string skuField;

        private string orderKeyField;

        private string orderLineNumberField;

        private string dropIDField;

        private string caseIDField;

        private string containerTypeField;

        private string intermodalvehicleField;

        private string loadIDField;

        private decimal qtyField;

        private string freightChargesField;

        private string cartonGroupField;

        private string cartonTypeField;

        private string trackingIDField;

        private decimal qtyRejectedField;

        private string rejectedReasonField;

        private string idField;

        private string descrField;

        private decimal stdGrossWgtField;

        private decimal stdNetWgtField;

        private decimal stdCubeField;

        private string classField;

        private string hazMatCodesKeyField;

        private string oCDFlagField;

        private string oCDLabel1Field;

        private string oCDLabel2Field;

        private string nonStockedIndicatorField;

        private string accountingEntityField;

        private string fillQtyUOMField;

        private string freightClassField;

        private string itemIDField;

        private string externOrderKeyField;

        private string externLineNoField;

        private string externAllocSequenceField;

        private string oDLottable09Field;

        private string oDLottable10Field;

        private string referenceTypeField;

        private string referenceDocumentField;

        private string referenceLocationField;

        private string referenceLineField;

        private string referenceAccountingEntityField;

        private string salesOrderDocumentField;

        private string salesOrderAccountingEntityField;

        private string salesOrderLocationField;

        private string salesOrderLineField;

        private string salesOrderScheduleLineField;

        private string notesField;

        private string referenceScheduleLineField;

        private string lottable03Field;

        private string lottable04Field;

        private string lottable05Field;

        private string packUOM3Field;

        private string widthUOM3Field;

        private string heightUOM3Field;

        private string lengthUOM3Field;

        private string packUOM1Field;

        private string widthUOM1Field;

        private string heightUOM1Field;

        private string lengthUOM1Field;

        private string caseCNTField;

        private string nMFCClassField;

        /// <remarks/>
        public string PickDetailKey
        {
            get
            {
                return this.pickDetailKeyField;
            }
            set
            {
                this.pickDetailKeyField = value;
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
        public string OrderKey
        {
            get
            {
                return this.orderKeyField;
            }
            set
            {
                this.orderKeyField = value;
            }
        }

        /// <remarks/>
        public string OrderLineNumber
        {
            get
            {
                return this.orderLineNumberField;
            }
            set
            {
                this.orderLineNumberField = value;
            }
        }

        /// <remarks/>
        public string DropID
        {
            get
            {
                return this.dropIDField;
            }
            set
            {
                this.dropIDField = value;
            }
        }

        /// <remarks/>
        public string CaseID
        {
            get
            {
                return this.caseIDField;
            }
            set
            {
                this.caseIDField = value;
            }
        }

        /// <remarks/>
        public string ContainerType
        {
            get
            {
                return this.containerTypeField;
            }
            set
            {
                this.containerTypeField = value;
            }
        }

        /// <remarks/>
        public string Intermodalvehicle
        {
            get
            {
                return this.intermodalvehicleField;
            }
            set
            {
                this.intermodalvehicleField = value;
            }
        }

        /// <remarks/>
        public string LoadID
        {
            get
            {
                return this.loadIDField;
            }
            set
            {
                this.loadIDField = value;
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
        public string FreightCharges
        {
            get
            {
                return this.freightChargesField;
            }
            set
            {
                this.freightChargesField = value;
            }
        }

        /// <remarks/>
        public string CartonGroup
        {
            get
            {
                return this.cartonGroupField;
            }
            set
            {
                this.cartonGroupField = value;
            }
        }

        /// <remarks/>
        public string CartonType
        {
            get
            {
                return this.cartonTypeField;
            }
            set
            {
                this.cartonTypeField = value;
            }
        }

        /// <remarks/>
        public string TrackingID
        {
            get
            {
                return this.trackingIDField;
            }
            set
            {
                this.trackingIDField = value;
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
        public string RejectedReason
        {
            get
            {
                return this.rejectedReasonField;
            }
            set
            {
                this.rejectedReasonField = value;
            }
        }

        /// <remarks/>
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
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
        public decimal StdNetWgt
        {
            get
            {
                return this.stdNetWgtField;
            }
            set
            {
                this.stdNetWgtField = value;
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
        public string Class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }

        /// <remarks/>
        public string HazMatCodesKey
        {
            get
            {
                return this.hazMatCodesKeyField;
            }
            set
            {
                this.hazMatCodesKeyField = value;
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
        public string FreightClass
        {
            get
            {
                return this.freightClassField;
            }
            set
            {
                this.freightClassField = value;
            }
        }

        /// <remarks/>
        public string ItemID
        {
            get
            {
                return this.itemIDField;
            }
            set
            {
                this.itemIDField = value;
            }
        }

        /// <remarks/>
        public string ExternOrderKey
        {
            get
            {
                return this.externOrderKeyField;
            }
            set
            {
                this.externOrderKeyField = value;
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
        public string ExternAllocSequence
        {
            get
            {
                return this.externAllocSequenceField;
            }
            set
            {
                this.externAllocSequenceField = value;
            }
        }

        /// <remarks/>
        public string ODLottable09
        {
            get
            {
                return this.oDLottable09Field;
            }
            set
            {
                this.oDLottable09Field = value;
            }
        }

        /// <remarks/>
        public string ODLottable10
        {
            get
            {
                return this.oDLottable10Field;
            }
            set
            {
                this.oDLottable10Field = value;
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

        /// <remarks/>
        public string WidthUOM3
        {
            get
            {
                return this.widthUOM3Field;
            }
            set
            {
                this.widthUOM3Field = value;
            }
        }

        /// <remarks/>
        public string HeightUOM3
        {
            get
            {
                return this.heightUOM3Field;
            }
            set
            {
                this.heightUOM3Field = value;
            }
        }

        /// <remarks/>
        public string LengthUOM3
        {
            get
            {
                return this.lengthUOM3Field;
            }
            set
            {
                this.lengthUOM3Field = value;
            }
        }

        /// <remarks/>
        public string PackUOM1
        {
            get
            {
                return this.packUOM1Field;
            }
            set
            {
                this.packUOM1Field = value;
            }
        }

        /// <remarks/>
        public string WidthUOM1
        {
            get
            {
                return this.widthUOM1Field;
            }
            set
            {
                this.widthUOM1Field = value;
            }
        }

        /// <remarks/>
        public string HeightUOM1
        {
            get
            {
                return this.heightUOM1Field;
            }
            set
            {
                this.heightUOM1Field = value;
            }
        }

        /// <remarks/>
        public string LengthUOM1
        {
            get
            {
                return this.lengthUOM1Field;
            }
            set
            {
                this.lengthUOM1Field = value;
            }
        }

        /// <remarks/>
        public string CaseCNT
        {
            get
            {
                return this.caseCNTField;
            }
            set
            {
                this.caseCNTField = value;
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShipmentConfirmationFacility
    {

        private string facilityField;

        private string typeField;

        private string companyField;

        private string vATField;

        private string address1Field;

        private string address2Field;

        private string address3Field;

        private string address4Field;

        private string cityField;

        private string stateField;

        private string postalCodeField;

        private string countryField;

        private string iSOCountryCodeField;

        private string contact1Field;

        private string phone1Field;

        private string fax1Field;

        private string email1Field;

        private string contact2Field;

        private string phone2Field;

        private string fax2Field;

        private string email2Field;

        private string b_Contact1Field;

        private string b_Contact2Field;

        private string b_CompanyField;

        private string b_Address1Field;

        private string b_Address2Field;

        private string b_Address3Field;

        private string b_Address4Field;

        private string b_CityField;

        private string b_StateField;

        private string b_PostalCodeField;

        private string b_CountryField;

        private string b_ISOCountryCodeField;

        private string b_Phone1Field;

        private string b_Phone2Field;

        private string b_Fax1Field;

        private string b_Fax2Field;

        private string notes1Field;

        private string notes2Field;

        private decimal creditLimitField;

        private string createPATaskOnRFReceiptField;

        private string calculatePutawayLocationField;

        private string cartonGroupField;

        private string pickCodeField;

        private string statusField;

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
        public string Company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }

        /// <remarks/>
        public string VAT
        {
            get
            {
                return this.vATField;
            }
            set
            {
                this.vATField = value;
            }
        }

        /// <remarks/>
        public string Address1
        {
            get
            {
                return this.address1Field;
            }
            set
            {
                this.address1Field = value;
            }
        }

        /// <remarks/>
        public string Address2
        {
            get
            {
                return this.address2Field;
            }
            set
            {
                this.address2Field = value;
            }
        }

        /// <remarks/>
        public string Address3
        {
            get
            {
                return this.address3Field;
            }
            set
            {
                this.address3Field = value;
            }
        }

        /// <remarks/>
        public string Address4
        {
            get
            {
                return this.address4Field;
            }
            set
            {
                this.address4Field = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string ISOCountryCode
        {
            get
            {
                return this.iSOCountryCodeField;
            }
            set
            {
                this.iSOCountryCodeField = value;
            }
        }

        /// <remarks/>
        public string Contact1
        {
            get
            {
                return this.contact1Field;
            }
            set
            {
                this.contact1Field = value;
            }
        }

        /// <remarks/>
        public string Phone1
        {
            get
            {
                return this.phone1Field;
            }
            set
            {
                this.phone1Field = value;
            }
        }

        /// <remarks/>
        public string Fax1
        {
            get
            {
                return this.fax1Field;
            }
            set
            {
                this.fax1Field = value;
            }
        }

        /// <remarks/>
        public string Email1
        {
            get
            {
                return this.email1Field;
            }
            set
            {
                this.email1Field = value;
            }
        }

        /// <remarks/>
        public string Contact2
        {
            get
            {
                return this.contact2Field;
            }
            set
            {
                this.contact2Field = value;
            }
        }

        /// <remarks/>
        public string Phone2
        {
            get
            {
                return this.phone2Field;
            }
            set
            {
                this.phone2Field = value;
            }
        }

        /// <remarks/>
        public string Fax2
        {
            get
            {
                return this.fax2Field;
            }
            set
            {
                this.fax2Field = value;
            }
        }

        /// <remarks/>
        public string Email2
        {
            get
            {
                return this.email2Field;
            }
            set
            {
                this.email2Field = value;
            }
        }

        /// <remarks/>
        public string B_Contact1
        {
            get
            {
                return this.b_Contact1Field;
            }
            set
            {
                this.b_Contact1Field = value;
            }
        }

        /// <remarks/>
        public string B_Contact2
        {
            get
            {
                return this.b_Contact2Field;
            }
            set
            {
                this.b_Contact2Field = value;
            }
        }

        /// <remarks/>
        public string B_Company
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
        public string B_Address1
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
        public string B_Address2
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
        public string B_Address3
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
        public string B_Address4
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
        public string B_City
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
        public string B_State
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
        public string B_PostalCode
        {
            get
            {
                return this.b_PostalCodeField;
            }
            set
            {
                this.b_PostalCodeField = value;
            }
        }

        /// <remarks/>
        public string B_Country
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
        public string B_ISOCountryCode
        {
            get
            {
                return this.b_ISOCountryCodeField;
            }
            set
            {
                this.b_ISOCountryCodeField = value;
            }
        }

        /// <remarks/>
        public string B_Phone1
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
        public string B_Phone2
        {
            get
            {
                return this.b_Phone2Field;
            }
            set
            {
                this.b_Phone2Field = value;
            }
        }

        /// <remarks/>
        public string B_Fax1
        {
            get
            {
                return this.b_Fax1Field;
            }
            set
            {
                this.b_Fax1Field = value;
            }
        }

        /// <remarks/>
        public string B_Fax2
        {
            get
            {
                return this.b_Fax2Field;
            }
            set
            {
                this.b_Fax2Field = value;
            }
        }

        /// <remarks/>
        public string Notes1
        {
            get
            {
                return this.notes1Field;
            }
            set
            {
                this.notes1Field = value;
            }
        }

        /// <remarks/>
        public string Notes2
        {
            get
            {
                return this.notes2Field;
            }
            set
            {
                this.notes2Field = value;
            }
        }

        /// <remarks/>
        public decimal CreditLimit
        {
            get
            {
                return this.creditLimitField;
            }
            set
            {
                this.creditLimitField = value;
            }
        }

        /// <remarks/>
        public string CreatePATaskOnRFReceipt
        {
            get
            {
                return this.createPATaskOnRFReceiptField;
            }
            set
            {
                this.createPATaskOnRFReceiptField = value;
            }
        }

        /// <remarks/>
        public string CalculatePutawayLocation
        {
            get
            {
                return this.calculatePutawayLocationField;
            }
            set
            {
                this.calculatePutawayLocationField = value;
            }
        }

        /// <remarks/>
        public string CartonGroup
        {
            get
            {
                return this.cartonGroupField;
            }
            set
            {
                this.cartonGroupField = value;
            }
        }

        /// <remarks/>
        public string PickCode
        {
            get
            {
                return this.pickCodeField;
            }
            set
            {
                this.pickCodeField = value;
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




}
