using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Infrastructure.Migrations
{
    public partial class SM001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Client",
            //    columns: table => new
            //    {
            //        DCLink = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Account = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Title = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
            //        PriceHalf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Init = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
            //        Contact_Person = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        Physical1 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Physical2 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Physical3 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Physical4 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Physical5 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        PhysicalPC = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
            //        Addressee = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        Post1 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Post2 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Post3 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Post4 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Post5 = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        PostPC = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
            //        Delivered_To = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        Telephone = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
            //        Telephone2 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
            //        Fax1 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
            //        Fax2 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
            //        AccountTerms = table.Column<int>(type: "int", nullable: true),
            //        CT = table.Column<bool>(type: "bit", nullable: false),
            //        Tax_Number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
            //        Registration = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        Credit_Limit = table.Column<double>(type: "float", nullable: true),
            //        RepID = table.Column<int>(type: "int", nullable: true),
            //        Interest_Rate = table.Column<double>(type: "float", nullable: true),
            //        Discount = table.Column<double>(type: "float", nullable: true),
            //        On_Hold = table.Column<bool>(type: "bit", nullable: false),
            //        BFOpenType = table.Column<int>(type: "int", nullable: true),
            //        EMail = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
            //        BankLink = table.Column<int>(type: "int", nullable: true),
            //        BranchCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        BankAccNum = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        BankAccType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        AutoDisc = table.Column<double>(type: "float", nullable: true),
            //        DiscMtrxRow = table.Column<int>(type: "int", nullable: true),
            //        MainAccLink = table.Column<int>(type: "int", nullable: true),
            //        CashDebtor = table.Column<bool>(type: "bit", nullable: false),
            //        DCBalance = table.Column<double>(type: "float", nullable: true),
            //        CheckTerms = table.Column<bool>(type: "bit", nullable: false),
            //        UseEmail = table.Column<bool>(type: "bit", nullable: false),
            //        iIncidentTypeID = table.Column<int>(type: "int", nullable: true),
            //        iBusTypeID = table.Column<int>(type: "int", nullable: true),
            //        iBusClassID = table.Column<int>(type: "int", nullable: true),
            //        iCountryID = table.Column<int>(type: "int", nullable: true),
            //        iAgentID = table.Column<int>(type: "int", nullable: true),
            //        dTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cAccDescription = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
            //        cWebPage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        iClassID = table.Column<int>(type: "int", nullable: true),
            //        iAreasID = table.Column<int>(type: "int", nullable: true),
            //        cBankRefNr = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        iCurrencyID = table.Column<int>(type: "int", nullable: true),
            //        bStatPrint = table.Column<bool>(type: "bit", nullable: false),
            //        bStatEmail = table.Column<bool>(type: "bit", nullable: false),
            //        cStatEmailPass = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        bForCurAcc = table.Column<bool>(type: "bit", nullable: false),
            //        fForeignBalance = table.Column<double>(type: "float", nullable: true),
            //        bTaxPrompt = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        iARPriceListNameID = table.Column<int>(type: "int", nullable: true),
            //        iSettlementTermsID = table.Column<int>(type: "int", nullable: false),
            //        bSourceDocPrint = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        bSourceDocEmail = table.Column<bool>(type: "bit", nullable: false),
            //        iEUCountryID = table.Column<int>(type: "int", nullable: false),
            //        iDefTaxTypeID = table.Column<int>(type: "int", nullable: false),
            //        bCODAccount = table.Column<bool>(type: "bit", nullable: false),
            //        udARDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        uiARDeliveryMethod = table.Column<int>(type: "int", nullable: true),
            //        tOrderNotes = table.Column<string>(type: "text", nullable: true, defaultValueSql: "('')"),
            //        uiARCATID = table.Column<int>(type: "int", nullable: true),
            //        FuelLevyPercen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        FLID = table.Column<int>(type: "int", nullable: false),
            //        AccountStatusID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        IGUFabRate = table.Column<double>(type: "float", nullable: false),
            //        CreditPercentage = table.Column<double>(type: "float", nullable: false),
            //        TotalDebitBalance = table.Column<double>(type: "float", nullable: false),
            //        TotInvoiced = table.Column<double>(type: "float", nullable: false),
            //        TotPending = table.Column<double>(type: "float", nullable: false),
            //        TotReceived = table.Column<double>(type: "float", nullable: false),
            //        IsGlobalAcc = table.Column<bool>(type: "bit", nullable: false),
            //        IsProspect = table.Column<bool>(type: "bit", nullable: false),
            //        CardIdentification = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')"),
            //        LegalName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        TrustName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        BusinessEstablished = table.Column<DateTime>(type: "smalldatetime", nullable: true),
            //        RegistrationNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('')"),
            //        ACN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('')"),
            //        Token = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true, defaultValueSql: "('')"),
            //        EntityStructureID = table.Column<int>(type: "int", nullable: false),
            //        InsuredID = table.Column<int>(type: "int", nullable: false),
            //        CreditApplicationDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
            //        PPS_ExpiryDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
            //        PersonalGurantee = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
            //        CC_NameOnCard = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        CC_CardNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
            //        CC_ExpiryDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
            //        BSB = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
            //        AcountNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        AcountName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        CreditSearch = table.Column<DateTime>(type: "smalldatetime", nullable: true),
            //        GONI = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        bSendOrderConfirmations = table.Column<bool>(type: "bit", nullable: false),
            //        EmailOrderConfirmationTo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValueSql: "('')"),
            //        EmailTaxInvoicesTo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValueSql: "('')"),
            //        EmailStatementsTo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValueSql: "('')"),
            //        RebateID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        XeroGUID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CLIENT", x => x.DCLink);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StkItem",
            //    columns: table => new
            //    {
            //        StockLink = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        Description_1 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        Description_2 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        Description_3 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        ItemGroup = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        Pack = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
            //        TTI = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
            //        TTC = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
            //        TTG = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
            //        TTR = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
            //        Bar_Code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        Re_Ord_Lvl = table.Column<double>(type: "float", nullable: true),
            //        Re_Ord_Qty = table.Column<double>(type: "float", nullable: true),
            //        Min_Lvl = table.Column<double>(type: "float", nullable: true),
            //        Max_Lvl = table.Column<double>(type: "float", nullable: true),
            //        AveUCst = table.Column<double>(type: "float", nullable: true),
            //        LatUCst = table.Column<double>(type: "float", nullable: true),
            //        LowUCst = table.Column<double>(type: "float", nullable: true),
            //        HigUCst = table.Column<double>(type: "float", nullable: true),
            //        StdUCst = table.Column<double>(type: "float", nullable: true),
            //        Qty_On_Hand = table.Column<double>(type: "float", nullable: true),
            //        LGrvCount = table.Column<double>(type: "float", nullable: true),
            //        ServiceItem = table.Column<bool>(type: "bit", nullable: false),
            //        ItemActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        ReservedQty = table.Column<double>(type: "float", nullable: true),
            //        QtyOnPO = table.Column<double>(type: "float", nullable: true),
            //        QtyOnSO = table.Column<double>(type: "float", nullable: true),
            //        WhseItem = table.Column<bool>(type: "bit", nullable: false),
            //        SerialItem = table.Column<bool>(type: "bit", nullable: false),
            //        DuplicateSN = table.Column<bool>(type: "bit", nullable: false),
            //        StrictSN = table.Column<bool>(type: "bit", nullable: false),
            //        BomCode = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
            //        SMtrxCol = table.Column<int>(type: "int", nullable: true),
            //        PMtrxCol = table.Column<int>(type: "int", nullable: true),
            //        JobQty = table.Column<double>(type: "float", nullable: true),
            //        cModel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        cRevision = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        cComponent = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        dDateReleased = table.Column<DateTime>(type: "smalldatetime", nullable: true),
            //        iBinLocationID = table.Column<int>(type: "int", nullable: true),
            //        dStkitemTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
            //        iInvSegValue1ID = table.Column<int>(type: "int", nullable: true),
            //        iInvSegValue2ID = table.Column<int>(type: "int", nullable: true),
            //        iInvSegValue3ID = table.Column<int>(type: "int", nullable: true),
            //        iInvSegValue4ID = table.Column<int>(type: "int", nullable: true),
            //        iInvSegValue5ID = table.Column<int>(type: "int", nullable: true),
            //        iInvSegValue6ID = table.Column<int>(type: "int", nullable: true),
            //        iInvSegValue7ID = table.Column<int>(type: "int", nullable: true),
            //        cExtDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        cSimpleCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        bCommissionItem = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        MFPQty = table.Column<double>(type: "float", nullable: true),
            //        bLotItem = table.Column<bool>(type: "bit", nullable: false),
            //        iLotStatus = table.Column<int>(type: "int", nullable: true),
            //        bLotMustExpire = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        iItemCostingMethod = table.Column<int>(type: "int", nullable: false),
            //        fItemLastGRVCost = table.Column<double>(type: "float", nullable: false),
            //        iEUCommodityID = table.Column<int>(type: "int", nullable: false),
            //        iEUSupplementaryUnitID = table.Column<int>(type: "int", nullable: false),
            //        fNetMass = table.Column<double>(type: "float", nullable: false),
            //        iUOMStockingUnitID = table.Column<int>(type: "int", nullable: true),
            //        iUOMDefPurchaseUnitID = table.Column<int>(type: "int", nullable: true),
            //        iUOMDefSellUnitID = table.Column<int>(type: "int", nullable: true),
            //        uiIISRVPRICEID = table.Column<int>(type: "int", nullable: true),
            //        ubIIEDGEALLOWANCE = table.Column<bool>(type: "bit", nullable: true),
            //        ufIIThickness = table.Column<double>(type: "float", nullable: true),
            //        ubIITemplate = table.Column<bool>(type: "bit", nullable: true),
            //        uiIITemplPriceID = table.Column<int>(type: "int", nullable: true),
            //        ubIIGLASSSERVICE = table.Column<bool>(type: "bit", nullable: true),
            //        uiIIItemType = table.Column<int>(type: "int", nullable: true),
            //        ufIIMINCHRG = table.Column<double>(type: "float", nullable: true),
            //        ufIIMINSQM = table.Column<double>(type: "float", nullable: true),
            //        ufIIWEIGHT = table.Column<double>(type: "float", nullable: true),
            //        uiIIPRICETYPEID = table.Column<int>(type: "int", nullable: true),
            //        ubIIPrintLabels = table.Column<bool>(type: "bit", nullable: true),
            //        DefaultGlassService = table.Column<bool>(type: "bit", nullable: false),
            //        IsLaminateItem = table.Column<bool>(type: "bit", nullable: false),
            //        ufIIQtyInVolume = table.Column<double>(type: "float", nullable: true),
            //        uiIIMainItemLink = table.Column<int>(type: "int", nullable: true),
            //        ubIIAllowNegative = table.Column<bool>(type: "bit", nullable: true),
            //        uiIISupplier = table.Column<int>(type: "int", nullable: true),
            //        uiIIWidth = table.Column<int>(type: "int", nullable: true),
            //        uiIIHeight = table.Column<int>(type: "int", nullable: true),
            //        ufIILotQty = table.Column<double>(type: "float", nullable: true),
            //        ufIIGrvQty = table.Column<double>(type: "float", nullable: true),
            //        ufIISOQtyVolume = table.Column<double>(type: "float", nullable: true),
            //        uiIIWarehouse = table.Column<double>(type: "float", nullable: true),
            //        ShowPODes = table.Column<bool>(type: "bit", nullable: false),
            //        IsNonStockItem = table.Column<bool>(type: "bit", nullable: false),
            //        IsExternalItem = table.Column<bool>(type: "bit", nullable: false),
            //        POMinimumArea = table.Column<double>(type: "float", nullable: false),
            //        AccountNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')"),
            //        CostCentre = table.Column<int>(type: "int", nullable: false),
            //        AddDetails = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        SalesAccount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        PurchaseAccount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Length = table.Column<double>(type: "float", nullable: true),
            //        BulkQty = table.Column<double>(type: "float", nullable: true),
            //        BulkRate = table.Column<double>(type: "float", nullable: true),
            //        PriceListItem = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        CalcPriceAsPercentage = table.Column<bool>(type: "bit", nullable: false),
            //        CalcPricePercentage = table.Column<double>(type: "float", nullable: false),
            //        BOMItem = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_STKITEM", x => x.StockLink);
            //    });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Client_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Client",
                        principalColumn: "DCLink",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_CustomerId",
                table: "OrderHeaders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHeaders");

            //migrationBuilder.DropTable(
            //    name: "StkItem");

            //migrationBuilder.DropTable(
            //    name: "Client");
        }
    }
}
