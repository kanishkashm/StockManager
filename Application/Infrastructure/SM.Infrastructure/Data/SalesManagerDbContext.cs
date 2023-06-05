using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SM.Core.Domain;
using SM.Infrastructure;

namespace SM.Infrastructure.Data
{
    public partial class SalesManagerDbContext : DbContext
    {
        public SalesManagerDbContext()
        {
        }

        public SalesManagerDbContext(DbContextOptions<SalesManagerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<StkItem> StkItems { get; set; } = null!;

        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Kanishka-Office\\SQLEXPRESS;Initial Catalog=SalesManagerDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Dclink)
                    .HasName("PK_CLIENT");

                entity.ToTable("Client");

                entity.Property(e => e.Dclink).HasColumnName("DCLink");

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AccountStatusId)
                    .HasColumnName("AccountStatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Acn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AcountName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AcountNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Addressee)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BCodaccount).HasColumnName("bCODAccount");

                entity.Property(e => e.BForCurAcc).HasColumnName("bForCurAcc");

                entity.Property(e => e.BSendOrderConfirmations).HasColumnName("bSendOrderConfirmations");

                entity.Property(e => e.BSourceDocEmail).HasColumnName("bSourceDocEmail");

                entity.Property(e => e.BSourceDocPrint)
                    .IsRequired()
                    .HasColumnName("bSourceDocPrint")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BStatEmail).HasColumnName("bStatEmail");

                entity.Property(e => e.BStatPrint).HasColumnName("bStatPrint");

                entity.Property(e => e.BTaxPrompt)
                    .IsRequired()
                    .HasColumnName("bTaxPrompt")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BankAccNum)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BfopenType).HasColumnName("BFOpenType");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bsb)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("BSB");

                entity.Property(e => e.BusinessEstablished).HasColumnType("smalldatetime");

                entity.Property(e => e.CAccDescription)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("cAccDescription");

                entity.Property(e => e.CBankRefNr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cBankRefNr");

                entity.Property(e => e.CStatEmailPass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cStatEmailPass");

                entity.Property(e => e.CWebPage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cWebPage");

                entity.Property(e => e.CardIdentification)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CcCardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CC_CardNumber");

                entity.Property(e => e.CcExpiryDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CC_ExpiryDate");

                entity.Property(e => e.CcNameOnCard)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CC_NameOnCard");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Contact_Person");

                entity.Property(e => e.CreditApplicationDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreditLimit).HasColumnName("Credit_Limit");

                entity.Property(e => e.CreditSearch).HasColumnType("smalldatetime");

                entity.Property(e => e.Ct).HasColumnName("CT");

                entity.Property(e => e.DTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("dTimeStamp");

                entity.Property(e => e.Dcbalance).HasColumnName("DCBalance");

                entity.Property(e => e.DeliveredTo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Delivered_To");

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.EmailOrderConfirmationTo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailStatementsTo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailTaxInvoicesTo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EntityStructureId).HasColumnName("EntityStructureID");

                entity.Property(e => e.FForeignBalance).HasColumnName("fForeignBalance");

                entity.Property(e => e.Fax1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Fax2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Flid).HasColumnName("FLID");

                entity.Property(e => e.FuelLevyPercen).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Goni)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GONI");

                entity.Property(e => e.IAgentId).HasColumnName("iAgentID");

                entity.Property(e => e.IAreasId).HasColumnName("iAreasID");

                entity.Property(e => e.IArpriceListNameId).HasColumnName("iARPriceListNameID");

                entity.Property(e => e.IBusClassId).HasColumnName("iBusClassID");

                entity.Property(e => e.IBusTypeId).HasColumnName("iBusTypeID");

                entity.Property(e => e.IClassId).HasColumnName("iClassID");

                entity.Property(e => e.ICountryId).HasColumnName("iCountryID");

                entity.Property(e => e.ICurrencyId).HasColumnName("iCurrencyID");

                entity.Property(e => e.IDefTaxTypeId).HasColumnName("iDefTaxTypeID");

                entity.Property(e => e.IEucountryId).HasColumnName("iEUCountryID");

                entity.Property(e => e.IIncidentTypeId).HasColumnName("iIncidentTypeID");

                entity.Property(e => e.ISettlementTermsId).HasColumnName("iSettlementTermsID");

                entity.Property(e => e.IgufabRate).HasColumnName("IGUFabRate");

                entity.Property(e => e.Init)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredId).HasColumnName("InsuredID");

                entity.Property(e => e.InterestRate).HasColumnName("Interest_Rate");

                entity.Property(e => e.LegalName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OnHold).HasColumnName("On_Hold");

                entity.Property(e => e.PersonalGurantee)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Physical1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Physical2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Physical3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Physical4)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Physical5)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalPc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PhysicalPC");

                entity.Property(e => e.Post1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Post2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Post3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Post4)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Post5)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PostPc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PostPC");

                entity.Property(e => e.PpsExpiryDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PPS_ExpiryDate");

                entity.Property(e => e.PriceHalf).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RebateId)
                    .HasColumnName("RebateID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Registration)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RepId).HasColumnName("RepID");

                entity.Property(e => e.TOrderNotes)
                    .HasColumnType("text")
                    .HasColumnName("tOrderNotes")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Tax_Number");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TrustName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UdArdate)
                    .HasColumnType("datetime")
                    .HasColumnName("udARDate");

                entity.Property(e => e.UiArcatid).HasColumnName("uiARCATID");

                entity.Property(e => e.UiArdeliveryMethod).HasColumnName("uiARDeliveryMethod");

                entity.Property(e => e.XeroGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("XeroGUID")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<StkItem>(entity =>
            {
                entity.HasKey(e => e.StockLink)
                    .HasName("PK_STKITEM");

                entity.ToTable("StkItem");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AveUcst).HasColumnName("AveUCst");

                entity.Property(e => e.BCommissionItem)
                    .IsRequired()
                    .HasColumnName("bCommissionItem")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BLotItem).HasColumnName("bLotItem");

                entity.Property(e => e.BLotMustExpire)
                    .IsRequired()
                    .HasColumnName("bLotMustExpire")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Bar_Code");

                entity.Property(e => e.BomCode)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Bomitem).HasColumnName("BOMItem");

                entity.Property(e => e.CComponent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cComponent");

                entity.Property(e => e.CExtDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cExtDescription");

                entity.Property(e => e.CModel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cModel");

                entity.Property(e => e.CRevision)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cRevision");

                entity.Property(e => e.CSimpleCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cSimpleCode");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DDateReleased)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dDateReleased");

                entity.Property(e => e.DStkitemTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("dStkitemTimeStamp");

                entity.Property(e => e.Description1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Description_1");

                entity.Property(e => e.Description2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Description_2");

                entity.Property(e => e.Description3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Description_3");

                entity.Property(e => e.DuplicateSn).HasColumnName("DuplicateSN");

                entity.Property(e => e.FItemLastGrvcost).HasColumnName("fItemLastGRVCost");

                entity.Property(e => e.FNetMass).HasColumnName("fNetMass");

                entity.Property(e => e.HigUcst).HasColumnName("HigUCst");

                entity.Property(e => e.IBinLocationId).HasColumnName("iBinLocationID");

                entity.Property(e => e.IEucommodityId).HasColumnName("iEUCommodityID");

                entity.Property(e => e.IEusupplementaryUnitId).HasColumnName("iEUSupplementaryUnitID");

                entity.Property(e => e.IInvSegValue1Id).HasColumnName("iInvSegValue1ID");

                entity.Property(e => e.IInvSegValue2Id).HasColumnName("iInvSegValue2ID");

                entity.Property(e => e.IInvSegValue3Id).HasColumnName("iInvSegValue3ID");

                entity.Property(e => e.IInvSegValue4Id).HasColumnName("iInvSegValue4ID");

                entity.Property(e => e.IInvSegValue5Id).HasColumnName("iInvSegValue5ID");

                entity.Property(e => e.IInvSegValue6Id).HasColumnName("iInvSegValue6ID");

                entity.Property(e => e.IInvSegValue7Id).HasColumnName("iInvSegValue7ID");

                entity.Property(e => e.IItemCostingMethod).HasColumnName("iItemCostingMethod");

                entity.Property(e => e.ILotStatus).HasColumnName("iLotStatus");

                entity.Property(e => e.IUomdefPurchaseUnitId).HasColumnName("iUOMDefPurchaseUnitID");

                entity.Property(e => e.IUomdefSellUnitId).HasColumnName("iUOMDefSellUnitID");

                entity.Property(e => e.IUomstockingUnitId).HasColumnName("iUOMStockingUnitID");

                entity.Property(e => e.ItemActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LatUcst).HasColumnName("LatUCst");

                entity.Property(e => e.LgrvCount).HasColumnName("LGrvCount");

                entity.Property(e => e.LowUcst).HasColumnName("LowUCst");

                entity.Property(e => e.MaxLvl).HasColumnName("Max_Lvl");

                entity.Property(e => e.Mfpqty).HasColumnName("MFPQty");

                entity.Property(e => e.MinLvl).HasColumnName("Min_Lvl");

                entity.Property(e => e.Pack)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PmtrxCol).HasColumnName("PMtrxCol");

                entity.Property(e => e.PominimumArea).HasColumnName("POMinimumArea");

                entity.Property(e => e.PriceListItem)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PurchaseAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QtyOnHand).HasColumnName("Qty_On_Hand");

                entity.Property(e => e.QtyOnPo).HasColumnName("QtyOnPO");

                entity.Property(e => e.QtyOnSo).HasColumnName("QtyOnSO");

                entity.Property(e => e.ReOrdLvl).HasColumnName("Re_Ord_Lvl");

                entity.Property(e => e.ReOrdQty).HasColumnName("Re_Ord_Qty");

                entity.Property(e => e.SalesAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShowPodes).HasColumnName("ShowPODes");

                entity.Property(e => e.SmtrxCol).HasColumnName("SMtrxCol");

                entity.Property(e => e.StdUcst).HasColumnName("StdUCst");

                entity.Property(e => e.StrictSn).HasColumnName("StrictSN");

                entity.Property(e => e.Ttc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TTC");

                entity.Property(e => e.Ttg)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TTG");

                entity.Property(e => e.Tti)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TTI");

                entity.Property(e => e.Ttr)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TTR");

                entity.Property(e => e.UbIiallowNegative).HasColumnName("ubIIAllowNegative");

                entity.Property(e => e.UbIiedgeallowance).HasColumnName("ubIIEDGEALLOWANCE");

                entity.Property(e => e.UbIiglassservice).HasColumnName("ubIIGLASSSERVICE");

                entity.Property(e => e.UbIiprintLabels).HasColumnName("ubIIPrintLabels");

                entity.Property(e => e.UbIitemplate).HasColumnName("ubIITemplate");

                entity.Property(e => e.UfIigrvQty).HasColumnName("ufIIGrvQty");

                entity.Property(e => e.UfIilotQty).HasColumnName("ufIILotQty");

                entity.Property(e => e.UfIiminchrg).HasColumnName("ufIIMINCHRG");

                entity.Property(e => e.UfIiminsqm).HasColumnName("ufIIMINSQM");

                entity.Property(e => e.UfIiqtyInVolume).HasColumnName("ufIIQtyInVolume");

                entity.Property(e => e.UfIisoqtyVolume).HasColumnName("ufIISOQtyVolume");

                entity.Property(e => e.UfIithickness).HasColumnName("ufIIThickness");

                entity.Property(e => e.UfIiweight).HasColumnName("ufIIWEIGHT");

                entity.Property(e => e.UiIiheight).HasColumnName("uiIIHeight");

                entity.Property(e => e.UiIiitemType).HasColumnName("uiIIItemType");

                entity.Property(e => e.UiIimainItemLink).HasColumnName("uiIIMainItemLink");

                entity.Property(e => e.UiIipricetypeid).HasColumnName("uiIIPRICETYPEID");

                entity.Property(e => e.UiIisrvpriceid).HasColumnName("uiIISRVPRICEID");

                entity.Property(e => e.UiIisupplier).HasColumnName("uiIISupplier");

                entity.Property(e => e.UiIitemplPriceId).HasColumnName("uiIITemplPriceID");

                entity.Property(e => e.UiIiwarehouse).HasColumnName("uiIIWarehouse");

                entity.Property(e => e.UiIiwidth).HasColumnName("uiIIWidth");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
