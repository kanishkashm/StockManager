﻿namespace SM.Core.Features.StkItem.Queries.GetStockItemDetals
{
    public class StockItemDetalsVm
    {
        public int StockLink { get; set; }
        public string? Code { get; set; }
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        public string? ItemGroup { get; set; }
        public string? Pack { get; set; }
        public string? Tti { get; set; }
        public string? Ttc { get; set; }
        public string? Ttg { get; set; }
        public string? Ttr { get; set; }
        public string? BarCode { get; set; }
        public double? ReOrdLvl { get; set; }
        public double? ReOrdQty { get; set; }
        public double? MinLvl { get; set; }
        public double? MaxLvl { get; set; }
        public double? AveUcst { get; set; }
        public double? LatUcst { get; set; }
        public double? LowUcst { get; set; }
        public double? HigUcst { get; set; }
        public double? StdUcst { get; set; }
        public double? QtyOnHand { get; set; }
        public double? LgrvCount { get; set; }
        public bool ServiceItem { get; set; }
        public bool? ItemActive { get; set; }
        public double? ReservedQty { get; set; }
        public double? QtyOnPo { get; set; }
        public double? QtyOnSo { get; set; }
        public bool WhseItem { get; set; }
        public bool SerialItem { get; set; }
        public bool DuplicateSn { get; set; }
        public bool StrictSn { get; set; }
        public string? BomCode { get; set; }
        public int? SmtrxCol { get; set; }
        public int? PmtrxCol { get; set; }
        public double? JobQty { get; set; }
        public string? CModel { get; set; }
        public string? CRevision { get; set; }
        public string? CComponent { get; set; }
        public DateTime? DDateReleased { get; set; }
        public int? IBinLocationId { get; set; }
        public DateTime? DStkitemTimeStamp { get; set; }
        public int? IInvSegValue1Id { get; set; }
        public int? IInvSegValue2Id { get; set; }
        public int? IInvSegValue3Id { get; set; }
        public int? IInvSegValue4Id { get; set; }
        public int? IInvSegValue5Id { get; set; }
        public int? IInvSegValue6Id { get; set; }
        public int? IInvSegValue7Id { get; set; }
        public string? CExtDescription { get; set; }
        public string? CSimpleCode { get; set; }
        public bool? BCommissionItem { get; set; }
        public double? Mfpqty { get; set; }
        public bool BLotItem { get; set; }
        public int? ILotStatus { get; set; }
        public bool? BLotMustExpire { get; set; }
        public int IItemCostingMethod { get; set; }
        public double FItemLastGrvcost { get; set; }
        public int IEucommodityId { get; set; }
        public int IEusupplementaryUnitId { get; set; }
        public double FNetMass { get; set; }
        public int? IUomstockingUnitId { get; set; }
        public int? IUomdefPurchaseUnitId { get; set; }
        public int? IUomdefSellUnitId { get; set; }
        public int? UiIisrvpriceid { get; set; }
        public bool? UbIiedgeallowance { get; set; }
        public double? UfIithickness { get; set; }
        public bool? UbIitemplate { get; set; }
        public int? UiIitemplPriceId { get; set; }
        public bool? UbIiglassservice { get; set; }
        public int? UiIiitemType { get; set; }
        public double? UfIiminchrg { get; set; }
        public double? UfIiminsqm { get; set; }
        public double? UfIiweight { get; set; }
        public int? UiIipricetypeid { get; set; }
        public bool? UbIiprintLabels { get; set; }
        public bool DefaultGlassService { get; set; }
        public bool IsLaminateItem { get; set; }
        public double? UfIiqtyInVolume { get; set; }
        public int? UiIimainItemLink { get; set; }
        public bool? UbIiallowNegative { get; set; }
        public int? UiIisupplier { get; set; }
        public int? UiIiwidth { get; set; }
        public int? UiIiheight { get; set; }
        public double? UfIilotQty { get; set; }
        public double? UfIigrvQty { get; set; }
        public double? UfIisoqtyVolume { get; set; }
        public double? UiIiwarehouse { get; set; }
        public bool ShowPodes { get; set; }
        public bool IsNonStockItem { get; set; }
        public bool IsExternalItem { get; set; }
        public double PominimumArea { get; set; }
        public string AccountNumber { get; set; } = null!;
        public int CostCentre { get; set; }
        public string? AddDetails { get; set; }
        public string? SalesAccount { get; set; }
        public string? PurchaseAccount { get; set; }
        public double? Length { get; set; }
        public double? BulkQty { get; set; }
        public double? BulkRate { get; set; }
        public bool? PriceListItem { get; set; }
        public bool CalcPriceAsPercentage { get; set; }
        public double CalcPricePercentage { get; set; }
        public bool Bomitem { get; set; }
    }
}
