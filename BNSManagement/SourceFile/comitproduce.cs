using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BNSManagement.SourceFile
{
    class comitproduce
    {
        static int globalgoodsidx;
        static int i = 1;
        public static void GoodsAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            i = 1;
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";

            SqlConnection CN = new SqlConnection(Conn);
           // SqlDataAdapter adapt;

            string CommandText = "SELECT TOP 1 GoodsId FROM Goods ORDER BY GoodsId DESC ";
            SqlCommand rungood = new SqlCommand(CommandText, CN);
            CN.Open();
            Int32 goodsID = (Int32)rungood.ExecuteScalar()+1;
            CN.Close();

            SqlCommand SqlCom = new SqlCommand("p_AddGoodsCore", CN);
            SqlCom.CommandType = CommandType.StoredProcedure;

            SqlCom.Parameters.Add("@GoodsId", SqlDbType.Int).Value = goodsID;
            SqlCom.Parameters.Add("@GoodsName", SqlDbType.NVarChar).Value = name;
            SqlCom.Parameters.Add("@GoodsAppGroupCode", SqlDbType.VarChar).Value = "bnsgrnTH";
            SqlCom.Parameters.Add("@GoodsType", SqlDbType.SmallInt).Value = 3;
            SqlCom.Parameters.Add("@DeliveryType", SqlDbType.SmallInt).Value = 1;
            SqlCom.Parameters.Add("@SaleStatus", SqlDbType.SmallInt).Value = 2;
            SqlCom.Parameters.Add("@EffectiveFrom", SqlDbType.DateTimeOffset).Value = Convert.ToDateTime("2020-01-01 00:00:00.000");
            SqlCom.Parameters.Add("@EffectiveTo", SqlDbType.DateTimeOffset).Value = Convert.ToDateTime("2099-12-31 23:59:59.000");
            SqlCom.Parameters.Add("@SaleableQuantity", SqlDbType.Int).Value = 0;
            SqlCom.Parameters.Add("@RefundUnitCode", SqlDbType.SmallInt).Value = 1;
            SqlCom.Parameters.Add("@IsRefundable", SqlDbType.Bit).Value = 0;
            SqlCom.Parameters.Add("@IsAvailableRecurringPayment", SqlDbType.Bit).Value = 1;
            SqlCom.Parameters.Add("@ChangerAdminAccount", SqlDbType.VarChar).Value = "KDXRSYSTEM";
            SqlCom.Parameters.Add("@GoodsDescription", SqlDbType.NVarChar).Value = desc;
            SqlCom.Parameters.Add("@GoodsData", SqlDbType.VarChar).Value = "AAAAAAE=";
            SqlCom.Parameters.Add("@ParentGoodsId", SqlDbType.Int).Value = DBNull.Value;
            SqlCom.Parameters.Add("@GoodsPurchaseType", SqlDbType.SmallInt).Value = 1;
            SqlCom.Parameters.Add("@GoodsPurchaseCheckMask", SqlDbType.Int).Value = 0;
            try
            {
                CN.Open();
                SqlCom.ExecuteNonQuery();
                MessageBox.Show(i+"Goods.DB Add");
                globalgoodsidx = goodsID;
                i++;
                GoodsCategoryAdd(name, price, itemid, maincat, subcat, desc);
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void GoodsCategoryAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);


            SqlCommand SqlCom = new SqlCommand("p_AddGoodsCategoryCore", CN);
            SqlCom.CommandType = CommandType.StoredProcedure;
            SqlCom.Parameters.Add("@GoodsId", SqlDbType.Int).Value = globalgoodsidx;
            SqlCom.Parameters.Add("@CategoryId", SqlDbType.SmallInt).Value = Convert.ToInt16(maincat);
            SqlCom.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = 1;

            SqlCommand SqlCom2 = new SqlCommand("p_AddGoodsCategoryCore", CN);
            if (subcat != null)
            {
                
                SqlCom2.CommandType = CommandType.StoredProcedure;
                SqlCom2.Parameters.Add("@GoodsId", SqlDbType.Int).Value = globalgoodsidx;
                SqlCom2.Parameters.Add("@CategoryId", SqlDbType.SmallInt).Value = Convert.ToInt16(subcat);
                SqlCom2.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = 1;
            }
            try
            {
                CN.Open();
                SqlCom.ExecuteNonQuery();
                if (subcat != null)
                    SqlCom2.ExecuteNonQuery();
                MessageBox.Show(i+"Categories.DB Add");
                i++;
                GoodsDisplayAdd(name, price, itemid, maincat, subcat, desc);
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void GoodsDisplayAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);


            SqlCommand SqlCom = new SqlCommand("p_AddGoodsDisplayCore", CN);
            SqlCom.CommandType = CommandType.StoredProcedure;
            SqlCom.Parameters.Add("@GoodsId", SqlDbType.Int).Value = globalgoodsidx;
            SqlCom.Parameters.Add("@LanguageCode", SqlDbType.SmallInt).Value = 11;
            SqlCom.Parameters.Add("@GoodsDisplayName", SqlDbType.NVarChar).Value = name;
            SqlCom.Parameters.Add("@GoodsDisplayDescription", SqlDbType.NVarChar).Value = desc;
            try
            {
                CN.Open();
                SqlCom.ExecuteNonQuery();
                MessageBox.Show(i+"GoodsDisplay.DB Add");
                i++;
                GoodsBasicPriceAdd(name, price, itemid, maincat, subcat, desc);
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void GoodsBasicPriceAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);


            SqlCommand SqlCom = new SqlCommand("p_AddGoodsBasicPriceCore", CN);
            SqlCom.CommandType = CommandType.StoredProcedure;
            SqlCom.Parameters.Add("@GoodsId", SqlDbType.Int).Value = globalgoodsidx;
            SqlCom.Parameters.Add("@CurrencyGroupId", SqlDbType.SmallInt).Value = 71;
            SqlCom.Parameters.Add("@BasicSalePrice", SqlDbType.Money).Value = 0;
            SqlCom.Parameters.Add("@RefundFee", SqlDbType.Money).Value = 0;
            try
            {
                CN.Open();
                SqlCom.ExecuteNonQuery();
                MessageBox.Show(i+"BasicPrice.DB Add");
                i++;
                GoodsSalePriceAdd(name, price, itemid, maincat, subcat, desc);
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void GoodsSalePriceAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);


            SqlCommand SqlCom = new SqlCommand("p_AddGoodsSalePricePolicyCore", CN);
            SqlCom.CommandType = CommandType.StoredProcedure;
            SqlCom.Parameters.Add("@GoodsId", SqlDbType.Int).Value = globalgoodsidx;
            SqlCom.Parameters.Add("@CurrencyGroupId", SqlDbType.SmallInt).Value = 71;
            SqlCom.Parameters.Add("@PricePolicyType", SqlDbType.SmallInt).Value = 1;
            SqlCom.Parameters.Add("@EffectiveFrom", SqlDbType.DateTimeOffset).Value = Convert.ToDateTime("2017-06-06 00:00:00.000");
            SqlCom.Parameters.Add("@EffectiveTo", SqlDbType.DateTimeOffset).Value = Convert.ToDateTime("2099-12-31 23:59:59.000");
            SqlCom.Parameters.Add("@SalePrice", SqlDbType.Money).Value = Convert.ToInt32(price);
            SqlCom.Parameters.Add("@DiscountValueType", SqlDbType.SmallInt).Value = DBNull.Value;
            SqlCom.Parameters.Add("@DiscountValue", SqlDbType.Money).Value = DBNull.Value;
            SqlCom.Parameters.Add("@DiscountKey", SqlDbType.VarChar).Value = DBNull.Value;
            SqlCom.Parameters.Add("@RewardValueType", SqlDbType.SmallInt).Value = DBNull.Value;
            SqlCom.Parameters.Add("@RewardValue", SqlDbType.Money).Value = DBNull.Value;
            SqlCom.Parameters.Add("@RewardTargetKey", SqlDbType.VarChar).Value = DBNull.Value;
            SqlCom.Parameters.Add("@RewardTargetKeyType", SqlDbType.SmallInt).Value = DBNull.Value;
            SqlCom.Parameters.Add("@GameGradeKey", SqlDbType.VarChar).Value = DBNull.Value;
            try
            {
                CN.Open();
                SqlCom.ExecuteNonQuery();
                MessageBox.Show(i+"SalePrice.DB Add");
                i++;
                GoodsItemsAdd(name, price, itemid, maincat, subcat, desc);
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void GoodsItemsAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);

            string CommandText = "SELECT * FROM Items WHERE ItemId =" + Convert.ToInt32(itemid);
            SqlCommand runcheck = new SqlCommand(CommandText, CN);
            CN.Open();
            string checkedable = Convert.ToString(runcheck.ExecuteScalar());
            CN.Close();
            if (checkedable == Convert.ToString(DBNull.Value))
            {
                SqlCommand SqlCom = new SqlCommand("p_AddItemCore", CN);
                SqlCom.CommandType = CommandType.StoredProcedure;
                SqlCom.Parameters.Add("@ItemId", SqlDbType.Int).Value = Convert.ToInt32(itemid);
                SqlCom.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = name;
                SqlCom.Parameters.Add("@ItemAppGroupCode", SqlDbType.VarChar).Value = "bnsgrnTH";
                SqlCom.Parameters.Add("@ItemType", SqlDbType.SmallInt).Value = 3;
                SqlCom.Parameters.Add("@IsConsumable", SqlDbType.Bit).Value = 0;
                SqlCom.Parameters.Add("@BasicPrice", SqlDbType.Money).Value = 0;
                SqlCom.Parameters.Add("@BasicCurrencyGroupId", SqlDbType.SmallInt).Value = 69;
                SqlCom.Parameters.Add("@ChangerAdminAccount", SqlDbType.VarChar).Value = "KDXRSYSTEM";
                SqlCom.Parameters.Add("@ItemDescription", SqlDbType.NVarChar).Value = desc;
                try
                {
                    CN.Open();
                    SqlCom.ExecuteNonQuery();
                    MessageBox.Show(i + "Items.DB Add");
                    i++;
                    GoodsItemsDisplayAdd(name, price, itemid, maincat, subcat, desc);
                    CN.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Items.DB Exist Skip");
                GoodsItemsDisplayAdd(name, price, itemid, maincat, subcat, desc);
            }
        }

        public static void GoodsItemsDisplayAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);

            string CommandText = "SELECT * FROM ItemDisplay WHERE ItemId =" + Convert.ToInt32(itemid);
            SqlCommand runcheck = new SqlCommand(CommandText, CN);
            CN.Open();
            string checkedable = Convert.ToString(runcheck.ExecuteScalar());
            CN.Close();
            if (checkedable == Convert.ToString(DBNull.Value))
            {

                SqlCommand SqlCom = new SqlCommand("p_AddItemDisplayCore", CN);
                SqlCom.CommandType = CommandType.StoredProcedure;
                SqlCom.Parameters.Add("@ItemId", SqlDbType.Int).Value = Convert.ToInt32(itemid);
                SqlCom.Parameters.Add("@LanguageCode", SqlDbType.SmallInt).Value = 11;
                SqlCom.Parameters.Add("@ItemDisplayName", SqlDbType.NVarChar).Value = name;
                SqlCom.Parameters.Add("@ItemDisplayDescription", SqlDbType.NVarChar).Value = desc;
                try
                {
                    CN.Open();
                    SqlCom.ExecuteNonQuery();
                    MessageBox.Show(i + "ItemsDisplay.DB Add");
                    i++;
                    GameItemAdd(name, price, itemid, maincat, subcat, desc);
                    CN.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("ItemsDisplay.DB Exist Skip");
                GameItemAdd(name, price, itemid, maincat, subcat, desc);
            }
        }

        public static void GameItemAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);

            string CommandText = "SELECT * FROM GameItems WHERE ItemId =" + Convert.ToInt32(itemid);
            SqlCommand runcheck = new SqlCommand(CommandText, CN);
            CN.Open();
            string checkedable = Convert.ToString(runcheck.ExecuteScalar());
            CN.Close();
            if (checkedable == Convert.ToString(DBNull.Value))
            {

                WebClient webClient = new WebClient();
                string key = webClient.DownloadString("http://154.202.3.61:81/generateitemkey.php?itemid=" + Convert.ToInt32(itemid));

                SqlCommand SqlCom = new SqlCommand("p_AddGameItemCore", CN);
                SqlCom.CommandType = CommandType.StoredProcedure;
                SqlCom.Parameters.Add("@ItemId", SqlDbType.Int).Value = Convert.ToInt32(itemid);
                SqlCom.Parameters.Add("@GameItemKey", SqlDbType.VarChar).Value = key;
                SqlCom.Parameters.Add("@GameItemData", SqlDbType.VarChar).Value = "AAAAAAAAAAA=";
                try
                {
                    CN.Open();
                    SqlCom.ExecuteNonQuery();
                    MessageBox.Show(i + "GameItems.DB Add");
                    i++;
                    GoodsItemAdd(name, price, itemid, maincat, subcat, desc);
                    CN.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("GameItems.DB Exist Skip");
                GoodsItemAdd(name, price, itemid, maincat, subcat, desc);
            }
        }

        public static void GoodsItemAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);

            /*string CommandText = "SELECT * FROM GoodsItems WHERE ItemId =" + Convert.ToInt32(itemid);
            SqlCommand runcheck = new SqlCommand(CommandText, CN);
            CN.Open();
            string checkedable = Convert.ToString(runcheck.ExecuteScalar());
            CN.Close();
            if (checkedable == Convert.ToString(DBNull.Value))
            {*/
                SqlCommand SqlCom = new SqlCommand("p_AddGoodsItemCore", CN);
                SqlCom.CommandType = CommandType.StoredProcedure;
                SqlCom.Parameters.Add("@GoodsId", SqlDbType.Int).Value = globalgoodsidx;
                SqlCom.Parameters.Add("@ItemId", SqlDbType.Int).Value = Convert.ToInt32(itemid);
                SqlCom.Parameters.Add("@ItemQuantity", SqlDbType.Int).Value = 1;
                SqlCom.Parameters.Add("@ItemExpirationType", SqlDbType.SmallInt).Value = 0;
                SqlCom.Parameters.Add("@ItemExpireAt", SqlDbType.DateTimeOffset).Value = DBNull.Value;
                SqlCom.Parameters.Add("@ItemExpirationDuration", SqlDbType.Int).Value = DBNull.Value;
                SqlCom.Parameters.Add("@ItemData", SqlDbType.VarChar).Value = "AAAAAAEA";
                SqlCom.Parameters.Add("@DeliveryPriority", SqlDbType.Int).Value = 1;
                SqlCom.Parameters.Add("@LimitedGameServerMask", SqlDbType.VarChar).Value = DBNull.Value;
                try
                {
                    CN.Open();
                    SqlCom.ExecuteNonQuery();
                    MessageBox.Show(i + "GoodItem.DB Add");
                    i++;
                    ChangeAdd(name, price, itemid, maincat, subcat, desc);
                    CN.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            /*}
            else
            {
                MessageBox.Show("GoodItem.DB Exist Skip");
                ChangeAdd(name, price, itemid, maincat, subcat, desc);
            }*/
        }

        public static void ChangeAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);

            string CommandText = "SELECT * FROM GoodsChanges WHERE ChangeId ="+ globalgoodsidx;
            SqlCommand runcheck = new SqlCommand(CommandText, CN);
            CN.Open();
            string checkedable = Convert.ToString(runcheck.ExecuteScalar());
            CN.Close();
            if (checkedable == Convert.ToString(DBNull.Value))
            {
                SqlCommand SqlCom = new SqlCommand("p_AddGoodsChangeCore", CN);
                SqlCom.CommandType = CommandType.StoredProcedure;

                SqlCom.Parameters.Add("@ChangeId", SqlDbType.Int).Value = globalgoodsidx;
                SqlCom.Parameters.Add("@ChangeType", SqlDbType.SmallInt).Value = 2;
                SqlCom.Parameters.Add("@RegistrarAdminAccount", SqlDbType.VarChar).Value = "KDXRSYSTEM";
                SqlCom.Parameters.Add("@ChangeDescription", SqlDbType.NVarChar).Value = DBNull.Value;
                SqlCom.Parameters.Add("@GoodsAppGroupCode", SqlDbType.VarChar).Value = "bnsgrnTH";
                SqlCom.Parameters.Add("@IsDisplayable", SqlDbType.Bit).Value = 1;
                try
                {
                    CN.Open();
                    SqlCom.ExecuteNonQuery();
                    MessageBox.Show(i + "GoodChange.DB Add");
                    i++;
                    GoodsItemBasicPriceAdd(name, price, itemid, maincat, subcat, desc);
                    CN.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("GoodChange.DB ExistItem");
                GoodsItemBasicPriceAdd(name, price, itemid, maincat, subcat, desc);
            }
        }

        public static void GoodsItemBasicPriceAdd(string name, string price, string itemid, string maincat, string subcat, string desc)
        {
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);


            SqlCommand SqlCom = new SqlCommand("p_AddGoodsItemBasicPriceCore", CN);
            SqlCom.CommandType = CommandType.StoredProcedure;
            SqlCom.Parameters.Add("@GoodsId", SqlDbType.Int).Value = globalgoodsidx;
            SqlCom.Parameters.Add("@ItemId", SqlDbType.Int).Value = Convert.ToInt32(itemid);
            SqlCom.Parameters.Add("@CurrencyGroupId", SqlDbType.SmallInt).Value = 0;
            SqlCom.Parameters.Add("@BasicSalePrice", SqlDbType.Money).Value = Convert.ToInt32(price);
            SqlCom.Parameters.Add("@BasicRefundPrice", SqlDbType.Money).Value = DBNull.Value;
            SqlCom.Parameters.Add("@BasicRefundPricePerSecond", SqlDbType.Money).Value = DBNull.Value;
            SqlCom.Parameters.Add("@BasicRefundPricePerHour", SqlDbType.Money).Value = DBNull.Value;
            SqlCom.Parameters.Add("@BasicRefundPricePerDay", SqlDbType.Money).Value = DBNull.Value;
            try
            {
                CN.Open();
                SqlCom.ExecuteNonQuery();
                MessageBox.Show(i + "ItemBasicPrice.DB Add");
                i++;
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }

}
