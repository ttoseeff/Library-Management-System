//using LinqToExcel;
//using Silkways.Models;
//using Silkways.Models.SilkwaysFunction;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;

//namespace Silkways.ExcelTemplateClasses
//{
//    public class NoonDotComTemplate
//    {
//        //public string sku_original { get; set; }
//        //public string model_name_number { get; set; }
//        //public string partner_sku { get; set; }
//        //public string product_subtype { get; set; }
//        //public string product_title_en { get; set; }
//        //public string brand_code { get; set; }
//        //public string MSRP { get; set; }
//        //public string Selling_Price { get; set; }
//        //public string qty { get; set; }
//        public string GTIN { get; set; }
//        public string Seller_SKU { get; set; }
//        public string Parent_SKU { get; set; }
//        public string Brand_Name { get; set; }
//        public string Product_Title { get; set; }
//        public string Product_Type { get; set; }
//        public string Product_Subtype { get; set; }
//        public string Country_of_Origin { get; set; }
//        public string Model_Number { get; set; }
//        public string Model_Name { get; set; }
//        public string F_Colour_Name { get; set; }
//        public string F_Colour_Family { get; set; }
//        public string F_Installation { get; set; }
//        public string F_Energy_Used { get; set; }
//        public string F_Material { get; set; }
//        public string F_Additional_Feature_1 { get; set; }
//        public string F_Additional_Feature_2 { get; set; }
//        public string FAdditional_Feature_3 { get; set; }
//        public string S_Product_Length { get; set; }
//        public string S_Length_Unit { get; set; }
//        public string S_Product_Height { get; set; }
//        public string S_Product_Height_Unit { get; set; }
//        public string S_Product_Width_Depth { get; set; }
//        public string S_Product_Width_Depth_Unit { get; set; }
//        public string S_Attribute_Key_1 { get; set; }
//        public string S_Attribute_Value_1 { get; set; }
//        public string S_Attribute_Key_2 { get; set; }
//        public string S_Attribute_Value_2 { get; set; }
//        public string S_Attribute_Key_3 { get; set; }
//        public string S_Attribute_Value_3 { get; set; }
//        public string S_Attribute_Key_4 { get; set; }
//        public string S_Attribute_Value_4 { get; set; }
//        public string S_Attribute_Key_5 { get; set; }
//        public string S_Attribute_Value_5 { get; set; }
//        public string Long_Description { get; set; }
//        public string F_Feature1 { get; set; }
//        public string F_Feature2 { get; set; }
//        public string F_Feature3 { get; set; }
//        public string F_Feature4 { get; set; }
//        public string F_Feature5 { get; set; }
//        public string Image_URL_1 { get; set; }
//        public string Image_URL_2 { get; set; }
//        public string Image_URL_3 { get; set; }
//        public string Image_URL_4 { get; set; }
//        public string Image_URL_5 { get; set; }
//        public string Image_URL_6 { get; set; }
//        public string Image_URL_7 { get; set; }
//        public string Shipping_Length_cm { get; set; }
//        public string Shipping_Height_cm { get; set; }
//        public string Shipping_Width { get; set; }//Depth_(cm)
//        public string Shipping_Weight_KG { get; set; }
//        public string Shipping_Destination { get; set; }
//        public string F_Warranty { get; set; }
//        public string Quantity { get; set; }///Stock
//        public string F_Fulfilment { get; set; }
//        public string Method { get; set; }
//        public string Processing_Time { get; set; }
//        public string MSRP_AE_Cost_AED { get; set; }
//        public string Price_AED { get; set; }
//        public string Sale_Price_AED { get; set; }
//        public static Dictionary<string, string> GetMappingDictionary()
//        {
//            Dictionary<string, string> MappingDictionary = new Dictionary<string, string>();
//            MappingDictionary.Add("Selling_Price", "Selling Price");
//            //MappingDictionary.Add("GTIN", "");
//            MappingDictionary.Add("Seller_SKU", "Seller SKU");
//            MappingDictionary.Add("Parent_SKU", "Parent SKU");
//            MappingDictionary.Add("Brand_Name", "Brand Name");
//            MappingDictionary.Add("Product_Title", "Product Title");
//            MappingDictionary.Add("Product_Type", "Product Type");
//            MappingDictionary.Add("Product_Subtype", "Product Subtype");
//            MappingDictionary.Add("Country_of_Origin", "Country of Origin");
//            MappingDictionary.Add("Model_Number", "Model Number");
//            MappingDictionary.Add("Model_Name", "ModelName");
//            MappingDictionary.Add("F_Colour_Name", "Colour Name");// Feature
//            MappingDictionary.Add("F_Colour_Family", "Colour Family");//Feature
//            MappingDictionary.Add("F_Installation", "Installation");//Feature 
//            MappingDictionary.Add("F_Energy_Used", "Energy Used");//Feature
//            MappingDictionary.Add("F_Material", "Material");//Feature
//            MappingDictionary.Add("F_Additional_Feature_1", "Additional Feature 1");
//            MappingDictionary.Add("F_Additional_Feature_2", "Additional Feature 2");
//            MappingDictionary.Add("FAdditional_Feature_3", "Additional Feature 3");
//            MappingDictionary.Add("S_Product_Length", "Product Length");
//            MappingDictionary.Add("S_Length_Unit", "Length Unit");
//            MappingDictionary.Add("S_Product_Height", "Product Height");
//            MappingDictionary.Add("S_Product_Height_Unit", "Height Unit");
//            MappingDictionary.Add("S_Product_Width_Depth", "Product Width/Depth");
//            MappingDictionary.Add("S_Product_Width_Depth_Unit", "Width/Depth Unit");
//            MappingDictionary.Add("S_Attribute_Key_1", "Attribute Key 1");
//            MappingDictionary.Add("S_Attribute_Value_1", "Attribute Value 1");
//            MappingDictionary.Add("S_Attribute_Key_2", "Attribute Key 2");
//            MappingDictionary.Add("S_Attribute_Value_2", "Attribute Value 2");
//            MappingDictionary.Add("S_Attribute_Key_3", "Attribute Key 3");
//            MappingDictionary.Add("S_Attribute_Value_3", "Attribute Value 3");
//            MappingDictionary.Add("S_Attribute_Key_4", "Attribute Key 4");
//            MappingDictionary.Add("S_Attribute_Value_4", "Attribute Value 4");
//            MappingDictionary.Add("S_Attribute_Key_5", "Attribute Key 5");
//            MappingDictionary.Add("S_Attribute_Value_5", "Attribute Value 5");
//            MappingDictionary.Add("Long_Description", "Long Description");
//            MappingDictionary.Add("F_Feature1", "Feature/Bullet 1");//Feature
//            MappingDictionary.Add("F_Feature2", "Feature/Bullet 2");//Feature
//            MappingDictionary.Add("F_Feature3", "Feature/Bullet 3");//Feature
//            MappingDictionary.Add("F_Feature4", "Feature/Bullet 4");//Feature
//            MappingDictionary.Add("F_Feature5", "Feature/Bullet 5");//Feature
//            MappingDictionary.Add("Image_URL_1", "Image URL 1");
//            MappingDictionary.Add("Image_URL_2", "Image URL 2");
//            MappingDictionary.Add("Image_URL_3", "Image URL 3");
//            MappingDictionary.Add("Image_URL_4", "Image URL 4");
//            MappingDictionary.Add("Image_URL_5", "Image URL 5");
//            MappingDictionary.Add("Image_URL_6", "Image URL 6");
//            MappingDictionary.Add("Image_URL_7", "Image URL 7");
//            MappingDictionary.Add("Shipping_Length_cm", "Shipping Length (cm)");
//            MappingDictionary.Add("Shipping_Height_cm", "Shipping Height (cm)");
//            MappingDictionary.Add("Shipping_Width", "Shipping Width");//Depth_(cm)
//            MappingDictionary.Add("Shipping_Weight_KG", "Shipping Weight (KG)");
//            MappingDictionary.Add("Shipping_Destination", "Shipping Destination");
//            MappingDictionary.Add("F_Warranty", "Warranty");
//            //MappingDictionary.Add("Quantity", "Quantity");///Stock
//            //MappingDictionary.Add("F_Fulfilment", "Fulfilment");
//            //MappingDictionary.Add("Method", "Method");
//            MappingDictionary.Add("Processing_Time", "Processing Time");
//            MappingDictionary.Add("MSRP_AE_Cost_AED", "MSRP AE Cost (AED)");
//            MappingDictionary.Add("Price_AED", "Price_(AED)");
//            MappingDictionary.Add("Sale_Price_AED", "Sale Price (AED)");
//            return MappingDictionary;
//        }
//        public static ExcelQueryFactory SetNoonDotComeSetting(ExcelQueryFactory excelFile)
//        {
//            var dictionary=NoonDotComTemplate.GetMappingDictionary();
//            foreach(var d in dictionary)
//            {
//                excelFile.AddMapping(d.Key,d.Value);
//            }
//            return excelFile;
//        }
//        public string ReturnFeaturesHtml()
//        {
//            var dictionary = NoonDotComTemplate.GetMappingDictionary();
//            //var dictionary = dictionary1.Where(d => d.Key.StartsWith("F_"));
//            string FeaturesHtml = "<table>";
//            foreach (var dic in dictionary)
//            {
//                if (dic.Key.StartsWith("F_"))
//                {
//                    if (!String.IsNullOrEmpty(this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate))))
//                    {
//                        FeaturesHtml = FeaturesHtml + "<tr><th>" + dic.Value + "</th>";
//                        FeaturesHtml = FeaturesHtml + "<td>" + this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate)) + "</td><tr>";
//                    }
//                }

//            }
//            #region oldLogic
//            //if (!String.IsNullOrEmpty(this.F_Colour_Name))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Colour_Name"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Colour_Name + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Colour_Family))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Colour_Family"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Colour_Family + "</td><tr>";
//            //}  
//            //if (!String.IsNullOrEmpty(this.F_Energy_Used))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Energy_Used"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Energy_Used + "</td><tr>";
//            //} 
//            //if (!String.IsNullOrEmpty(this.F_Installation))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Installation"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Installation + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Material))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Material"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Material + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Fulfilment))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Fulfilment"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Fulfilment + "</td><tr>";
//            //}

//            //if (!String.IsNullOrEmpty(this.GetPropertyVal("F_Feature1")))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Feature1"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.GetPropertyVal("F_Feature1") + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Feature2))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Feature2"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Feature2 + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Feature3))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Feature3"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Feature3 + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Feature4))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Feature4"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Feature4 + "</td><tr>";
//            //} 
//            //if (!String.IsNullOrEmpty(this.F_Feature5))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Feature5"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Feature5 + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Additional_Feature_1))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Additional_Feature_1"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Additional_Feature_1 + "</td><tr>";
//            //} 
//            //if (!String.IsNullOrEmpty(this.F_Additional_Feature_2))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Additional_Feature_2"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Additional_Feature_2 + "</td><tr>";
//            //} 
//            //if (!String.IsNullOrEmpty(this.F_Energy_Used))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Energy_Used"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Energy_Used + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.F_Warranty))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["F_Warranty"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.F_Warranty + "</td><tr>";
//            //}
//            #endregion
//            if (FeaturesHtml== "<table>")
//            {
//                FeaturesHtml = "";
//            }
//            else
//            {
//                FeaturesHtml = FeaturesHtml + "</table>";
//            }
//            return FeaturesHtml;
//        }
//        public string ReturnSpecficationHtml()
//        {
//            var dictionary = NoonDotComTemplate.GetMappingDictionary();
//            string FeaturesHtml = "<table>";
//            foreach (var dic in dictionary)
//            {
//                if (dic.Key.StartsWith("S_"))
//                {
//                    if (dic.Key.Contains("S_Attribute_Value"))
//                    {
//                        continue;
//                    }
//                    else if (dic.Key.Contains("S_Attribute_Key"))
//                    {
//                        if (!String.IsNullOrEmpty(this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate))) && !String.IsNullOrEmpty(dic.Value))
//                        {
//                            FeaturesHtml = FeaturesHtml + "<tr><th>" + this.GetPropertyVal(dic.Key.Replace("S_Attribute_Key", "S_Attribute_Value"), this, typeof(NoonDotComTemplate)) + "</th>";
//                            FeaturesHtml = FeaturesHtml + "<td>" + this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate)) + "</td><tr>";
//                        }
//                    }
//                    else if (!String.IsNullOrEmpty(this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate))) && !String.IsNullOrEmpty(dic.Value))
//                    {
//                        FeaturesHtml = FeaturesHtml + "<tr><th>" + dic.Value + "</th>";
//                        FeaturesHtml = FeaturesHtml + "<td>" + this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate)) + "</td><tr>";
//                    }
//                }

//            }
//            #region old Logic
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_1)&& !String.IsNullOrEmpty(this.S_Attribute_Key_1))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Attribute_Key_1"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Attribute_Value_1 + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_2) && !String.IsNullOrEmpty(this.S_Attribute_Key_2))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Attribute_Key_2"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Attribute_Value_2 + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_3) && !String.IsNullOrEmpty(this.S_Attribute_Key_3))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Attribute_Key_3"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Attribute_Value_3 + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_4) && !String.IsNullOrEmpty(this.S_Attribute_Key_4))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Attribute_Key_4"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Attribute_Value_4 + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_5) && !String.IsNullOrEmpty(this.S_Attribute_Key_5))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Attribute_Key_5"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Attribute_Value_5 + "</td><tr>";
//            //}
//            ///////////
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_5) && !String.IsNullOrEmpty(this.S_Attribute_Key_5))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Product_Length"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Product_Length + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Length_Unit) && !String.IsNullOrEmpty(this.S_Length_Unit))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Length_Unit"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Length_Unit + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Product_Height) && !String.IsNullOrEmpty(this.S_Product_Height))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Product_Height"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Product_Height + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_5) && !String.IsNullOrEmpty(this.S_Attribute_Key_5))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Product_Width_Depth"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Product_Width_Depth + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Product_Height_Unit) && !String.IsNullOrEmpty(this.S_Product_Height_Unit))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Product_Height_Unit"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Product_Height_Unit + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Product_Width_Depth) && !String.IsNullOrEmpty(this.S_Product_Width_Depth))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Product_Width_Depth"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Product_Width_Depth + "</td><tr>";
//            //}
//            //if (!String.IsNullOrEmpty(this.S_Attribute_Value_5) && !String.IsNullOrEmpty(this.S_Attribute_Key_5))
//            //{
//            //    FeaturesHtml = FeaturesHtml + "<tr><th>" + dictionary["S_Product_Width_Depth_Unit"] + "</th>";
//            //    FeaturesHtml = FeaturesHtml + "<td>" + this.S_Product_Width_Depth_Unit + "</td><tr>";
//            //}
//            #endregion
//            FeaturesHtml = FeaturesHtml + "</table>";
//            if (FeaturesHtml == "<table>")
//            {
//                FeaturesHtml = "";
//            }
//            else
//            {
//                FeaturesHtml = FeaturesHtml + "</table>";
//            }
//            return FeaturesHtml;
//        }
//        public Product SaveImage(Product prd,string path,bool isfirstExicution,Type type)
//        {
//            List<ProductPhoto> prdPhotos = new List<ProductPhoto>();
//            var dictionary = NoonDotComTemplate.GetMappingDictionary();
//            if (isfirstExicution)
//            {
//                foreach (var dic in dictionary)
//                {
//                    if (dic.Key.StartsWith("Image_URL_"))
//                    {
//                        if (!String.IsNullOrEmpty(this.GetPropertyVal(dic.Key, this, type)))
//                        {
//                            ProductPhoto prdPhoto = new ProductPhoto();
//                            prdPhoto.Thumbnail = this.GetPropertyVal(dic.Key, this, type);
//                            string[] Name = this.GetPropertyVal(dic.Key, this, type).Split('/');
//                            string fName = "";
//                            fName = "M-" + Name[Name.Length - 1];
//                            prdPhoto.MedPhoto = fName;
//                            fName = "L-" + Name[Name.Length - 1];
//                            prdPhoto.LargePhoto = fName;
//                            prdPhotos.Add(prdPhoto);
//                        }
//                    }

//                }
//            }
//            else
//            {
//                prdPhotos.AddRange(prd.ProductPhotos);
//            }
//            #region oldLogic
//            //if (!String.IsNullOrEmpty(this.Image_URL_1))
//            //{
//            //   ProductPhoto prdPhoto = new ProductPhoto();
//            //    prdPhoto.Thumbnail=this.Image_URL_1;
//            //    string[] Name = this.Image_URL_1.Split('/');
//            //    string fName = "";
//            //    fName = "M-" + Name[Name.Length - 1];
//            //    prdPhoto.MedPhoto = fName;
//            //    fName = "L-" + Name[Name.Length - 1];
//            //    prdPhoto.LargePhoto = fName;
//            //    //fName = "T-" + Name[Name.Length - 1];
//            //    //prdPhoto.Thumbnail = fName;
//            //    prdPhotos.Add(prdPhoto);
//            //}
//            //if (!String.IsNullOrEmpty(this.Image_URL_2))
//            //{
//            //    ProductPhoto prdPhoto = new ProductPhoto();
//            //    prdPhoto.Thumbnail = this.Image_URL_2;
//            //    string[] Name = this.Image_URL_2.Split('/');
//            //    string fName = "";
//            //    fName = "M-" + Name[Name.Length - 1];
//            //    prdPhoto.MedPhoto = fName;
//            //    fName = "L-" + Name[Name.Length - 1];
//            //    prdPhoto.LargePhoto = fName;
//            //    prdPhotos.Add(prdPhoto);
//            //}
//            //if (!String.IsNullOrEmpty(this.Image_URL_3))
//            //{
//            //    ProductPhoto prdPhoto = new ProductPhoto();
//            //    prdPhoto.Thumbnail = this.Image_URL_3;
//            //    string[] Name = this.Image_URL_3.Split('/');
//            //    string fName = "";
//            //    fName = "M-" + Name[Name.Length - 1];
//            //    prdPhoto.MedPhoto = fName;
//            //    fName = "L-" + Name[Name.Length - 1];
//            //    prdPhoto.LargePhoto = fName;
//            //    prdPhotos.Add(prdPhoto);
//            //}
//            //if (!String.IsNullOrEmpty(this.Image_URL_4))
//            //{
//            //    ProductPhoto prdPhoto = new ProductPhoto();
//            //    prdPhoto.Thumbnail = this.Image_URL_4;
//            //    string[] Name = this.Image_URL_4.Split('/');
//            //    string fName = "";
//            //    fName = "M-" + Name[Name.Length - 1];
//            //    prdPhoto.MedPhoto = fName;
//            //    fName = "L-" + Name[Name.Length - 1];
//            //    prdPhoto.LargePhoto = fName;
//            //    prdPhotos.Add(prdPhoto);
//            //}
//            //if (!String.IsNullOrEmpty(this.Image_URL_5))
//            //{
//            //    ProductPhoto prdPhoto = new ProductPhoto();
//            //    prdPhoto.Thumbnail = this.Image_URL_5;
//            //    string[] Name = this.Image_URL_5.Split('/');
//            //    string fName = "";
//            //    fName = "M-" + Name[Name.Length - 1];
//            //    prdPhoto.MedPhoto = fName;
//            //    fName = "L-" + Name[Name.Length - 1];
//            //    prdPhoto.LargePhoto = fName;
//            //    prdPhotos.Add(prdPhoto);
//            //}
//            //if (!String.IsNullOrEmpty(this.Image_URL_6))
//            //{
//            //    ProductPhoto prdPhoto = new ProductPhoto();
//            //    prdPhoto.Thumbnail = this.Image_URL_6;
//            //    string[] Name = this.Image_URL_6.Split('/');
//            //    string fName = "";
//            //    fName = "M-" + Name[Name.Length - 1];
//            //    prdPhoto.MedPhoto = fName;
//            //    fName = "L-" + Name[Name.Length - 1];
//            //    prdPhoto.LargePhoto = fName;
//            //    prdPhotos.Add(prdPhoto);
//            //}
//            //if (!String.IsNullOrEmpty(this.Image_URL_7))
//            //{
//            //    ProductPhoto prdPhoto = new ProductPhoto();
//            //    prdPhoto.Thumbnail = this.Image_URL_7;
//            //    string[] Name = this.Image_URL_7.Split('/');
//            //    string fName = "";
//            //    fName = "M-" + Name[Name.Length - 1];
//            //    prdPhoto.MedPhoto = fName;
//            //    fName = "L-" + Name[Name.Length - 1];
//            //    prdPhoto.LargePhoto = fName;
//            //    prdPhotos.Add(prdPhoto);
//            //}
//            #endregion
//            string pathreserved =path;
//            foreach(var ph in prdPhotos)
//            {
//                path=pathreserved;
//                byte[] data1;
//                    using (System.Net.WebClient client = new System.Net.WebClient())
//                    {
//                        data1 = client.DownloadData(ph.Thumbnail);
//                    }
//                string[] Name = ph.Thumbnail.Split('/');
//                string fName = "";
//                string oldfName = Name[Name.Length - 1];
//                fName = "T-" + Name[Name.Length - 1];
//                string oldpath = path + "\\" + oldfName;
//                if (!Directory.Exists(oldpath))
//                {
//                    Directory.CreateDirectory(path);
//                }
//                File.WriteAllBytes(oldpath, data1);
//                string newpath = "";
//                var brandName = "";
//                if (!isfirstExicution)
//                {
//                    if (prd.ProductBrand == null)
//                    {
//                         genericadminEntities db = new Models.genericadminEntities();
//                        brandName=db.ProductBrands.Find(prd.BrandID).BrandName;
//                        newpath = path + "\\" + brandName;
//                    }
//                    else
//                    {
//                        brandName = prd.ProductBrand.BrandName;
//                        newpath = path + "\\" + prd.ProductBrand.BrandName;
//                    }
//                }
//                else
//                {
//                    brandName= this.Brand_Name.Trim();
//                    newpath = path + "\\" + this.Brand_Name.Trim();
//                }
//                if (!Directory.Exists(newpath))
//                {
//                    Directory.CreateDirectory(path);
//                }
//                path = newpath + "\\" + fName;
//                try
//                {
//                GernalFunction.Resize_Image_Thumb(oldpath, oldfName, 500, 500, fName, path);
//                    Silkways.Models.SilkwaysFunction.GernalFunction.FTPBE ce = new Silkways.Models.SilkwaysFunction.GernalFunction.FTPBE();
//                    var remotePath = path.Replace("\\","/");
//                    ce.HostFilePath = remotePath + fName;
//                    ce.TransferFilePath = "ftp://184.154.206.133/Resources/ProductsImages/"+brandName+"/"+ fName;
//                    ce.FileName = fName;
//                    if (!Directory.Exists(ce.TransferFilePath))
//                    {
//                        Directory.CreateDirectory(ce.TransferFilePath);
//                    }
//                    var ISDone = Silkways.Models.SilkwaysFunction.GernalFunction.FtpUploads.FtpUploadUsingFileUpload(ce);
//                }
//                catch(Exception ex)
//                {

//                }
//                path = newpath + "\\" + ph.MedPhoto;
//                try
//                {
//                GernalFunction.Resize_Image_Thumb(oldpath, oldfName, 800, 800, fName, path);

//                }
//                catch(Exception ex)
//                {

//                }
//                path = newpath + "\\" + ph.LargePhoto;
//                try
//                {
//                GernalFunction.Resize_Image_Thumb(oldpath, oldfName, 1000, 10000, fName, path);
//                }
//                catch(Exception ex)
//                {

//                }
//                ph.Thumbnail = fName;
//                //Directory.Delete(oldpath);
//                //prd.ProductPhotos.Add(ph);
//            }
//            prd.ProductPhotos = prdPhotos;
//            return prd;
//        }
//        public Product SetUnSaveImages(Product prd)
//        {
//            List<ProductPhoto> prdPhotos = new List<ProductPhoto>();
//            var dictionary = NoonDotComTemplate.GetMappingDictionary();
//            foreach (var dic in dictionary)
//            {
//                if (dic.Key.StartsWith("Image_URL_"))
//                {
//                    if (!String.IsNullOrEmpty(this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate))))
//                    {
//                        ProductPhoto prdPhoto = new ProductPhoto();
//                        prdPhoto.Thumbnail = this.GetPropertyVal(dic.Key,this,typeof(NoonDotComTemplate));
//                        string[] Name = this.GetPropertyVal(dic.Key, this, typeof(NoonDotComTemplate)).Split('/');
//                        string fName = "";
//                        fName = "M-" + Name[Name.Length - 1];
//                        prdPhoto.MedPhoto = fName;
//                        fName = "L-" + Name[Name.Length - 1];
//                        prdPhoto.LargePhoto = fName;
//                        prdPhotos.Add(prdPhoto);
//                    }
//                }

//            }
//            prd.ProductPhotos = prdPhotos;
//            return prd;
//        }
//        public string GetPropertyVal(string propertyName,object obj,Type tp)//Need seprate
//        {
//            Type myType = typeof(NoonDotComTemplate);
//            System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
//            var properyVal = myPropInfo.GetValue(obj, null);
            
//            var properyValString = properyVal!=null?properyVal.ToString():"";
//            return properyValString;
//        }
//    }
//}