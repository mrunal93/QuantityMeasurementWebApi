using Microsoft.Extensions.Configuration;
using QuantityMeasurementModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;

namespace QuantityMeasurementRepositoryLayer
{
    public class UnitQuantityRepository : IUnitQuantityRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public UnitQuantityRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public object LengthConvertor(LengthModel unit)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddLengthValues", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                {
                    object result;
                    switch (unit.UnitOption)
                    {
                        case " FEET_TO_INCH":
                            unit.Inch = unit.Feet * 12.0f;
                            sqlCommand.Parameters.AddWithValue("@feet", unit.Feet);
                            sqlCommand.Parameters.AddWithValue("@inch", unit.Inch);
                            sqlCommand.Parameters.AddWithValue("@yard", unit.Yard);
                            sqlCommand.Parameters.AddWithValue("@centimeter", unit.Centimeter);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Inch;
                            break;
                        case "INCH_TO_FEET":
                            unit.Feet = unit.Inch / 12.0f;
                            sqlCommand.Parameters.AddWithValue("@feet", unit.Feet);
                            sqlCommand.Parameters.AddWithValue("@inch", unit.Inch);
                            sqlCommand.Parameters.AddWithValue("@yard", unit.Yard);
                            sqlCommand.Parameters.AddWithValue("@centimeter", unit.Centimeter);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Feet;
                            break;
                        case "INCH_TO_CENTIMETER":
                            unit.Centimeter = unit.Inch * 2.54f;
                            sqlCommand.Parameters.AddWithValue("@feet", unit.Feet);
                            sqlCommand.Parameters.AddWithValue("@inch", unit.Inch);
                            sqlCommand.Parameters.AddWithValue("@yard", unit.Yard);
                            sqlCommand.Parameters.AddWithValue("@centimeter", unit.Centimeter);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Centimeter;
                            break;
                        case "CENTIMETER_TO_INCH":
                            unit.Inch = unit.Centimeter / 2.54f;
                            sqlCommand.Parameters.AddWithValue("@feet", unit.Feet);
                            sqlCommand.Parameters.AddWithValue("@inch", unit.Inch);
                            sqlCommand.Parameters.AddWithValue("@yard", unit.Yard);
                            sqlCommand.Parameters.AddWithValue("@centimeter", unit.Centimeter);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Inch;
                            break;
                        case "YARD_TO_FEET":
                            unit.Feet = unit.Yard * 3.00f;
                            sqlCommand.Parameters.AddWithValue("@feet", unit.Feet);
                            sqlCommand.Parameters.AddWithValue("@inch", unit.Inch);
                            sqlCommand.Parameters.AddWithValue("@yard", unit.Yard);
                            sqlCommand.Parameters.AddWithValue("@centimeter", unit.Centimeter);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Yard;
                            break;
                        case "FEET_TO_YARD":
                            unit.Yard = unit.Feet / 3.00f;
                            sqlCommand.Parameters.AddWithValue("@feet", unit.Feet);
                            sqlCommand.Parameters.AddWithValue("@inch", unit.Inch);
                            sqlCommand.Parameters.AddWithValue("@yard", unit.Yard);
                            sqlCommand.Parameters.AddWithValue("@centimeter", unit.Centimeter);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);
                            
                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Feet;
                            break;
                        default:
                            result = new Exception("An Error Accured");
                            break;

                    }
                    return result;
                }
            }
            catch (Exception e)
            {

                throw new Exception ("An Error Accured:" +e);
            }
           
        }

        public object TempretureConvertor(TemperetureModel unit)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_ConverTempreture", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                {
                    object result;
                    switch (unit.UnitOption) 
                    {
                        case "FAHRENHIET_TO_CELCIUS":
                            unit.Celcius = ((unit.Fahrenhiet - 32.0f) * 5.0f / 9.0f);
                            sqlCommand.Parameters.AddWithValue("@fahrenhiet", unit.Fahrenhiet);
                            sqlCommand.Parameters.AddWithValue("@celcius", unit.Celcius);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Celcius;
                            break;
                        case "CELCIUS_TO_FAHRENHIET":
                            unit.Fahrenhiet = ((unit.Celcius * 9.0f / 5.0f) + 32.0f);
                            sqlCommand.Parameters.AddWithValue("@fahrenhiet", unit.Fahrenhiet);
                            sqlCommand.Parameters.AddWithValue("@celcius", unit.Celcius);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Fahrenhiet;
                            break;
                        default:
                            result = new Exception("An Error Accour:");
                            break;
                    }
                    return result;
                }
            }
            catch (Exception e)
            {

                throw new Exception("An Error Accured:" + e);
            }
        }

        public object WeightConvertor(WeightModel unit)
        {
            try
            {

                SqlCommand sqlCommand = new SqlCommand("sp_ConverTempreture", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                {
                    object result;
                    switch (unit.UnitOption)
                    {
                        case "KILOGRSM_TO_GRAM":
                            unit.Gram = unit.Kilogram * 1000;
                            sqlCommand.Parameters.AddWithValue("@gram", unit.Gram);
                            sqlCommand.Parameters.AddWithValue("@kilogram", unit.Kilogram);
                            sqlCommand.Parameters.AddWithValue("@tonne", unit.Tonne);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Gram;
                            break;
                        case "GRAM_TO_KILOGRAM":
                            unit.Kilogram = unit.Gram / 1000;
                            sqlCommand.Parameters.AddWithValue("@gram", unit.Gram);
                            sqlCommand.Parameters.AddWithValue("@kilogram", unit.Kilogram);
                            sqlCommand.Parameters.AddWithValue("@tonne", unit.Tonne);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Kilogram;
                            break;
                        case "TONNE_TO_KILOGRAM":
                            unit.Kilogram = unit.Tonne * 1000;
                            sqlCommand.Parameters.AddWithValue("@gram", unit.Gram);
                            sqlCommand.Parameters.AddWithValue("@kilogram", unit.Kilogram);
                            sqlCommand.Parameters.AddWithValue("@tonne", unit.Tonne);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Kilogram;
                            break;
                        case "KILOGRAM_TO_TONE":
                            unit.Tonne = unit.Kilogram / 1000;
                            sqlCommand.Parameters.AddWithValue("@gram", unit.Gram);
                            sqlCommand.Parameters.AddWithValue("@kilogram", unit.Kilogram);
                            sqlCommand.Parameters.AddWithValue("@tonne", unit.Tonne);
                            sqlCommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            result = unit.Tonne;
                            break;
                        default:
                            result = new Exception("An Error Accour:");
                            break;
                    }
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception("An Error Accured:" + e);
            }
            }
        

        public object VolumeConvertor(VolumeModel unit)
        {
            try
            {

                SqlCommand sqlcommand = new SqlCommand("sp_VolumeConvertor", sqlConnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;

                object result;
                switch (unit.UnitOption)
                {
                    case "LITRE_TO_GALLON":
                        unit.Gallon = unit.Litre / 3.785f;
                        sqlcommand.Parameters.AddWithValue("@liter", unit.Litre);
                        sqlcommand.Parameters.AddWithValue("@gallon", unit.Gallon);
                        sqlcommand.Parameters.AddWithValue("@milliliter", unit.Milliliter);
                        sqlcommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);

                        sqlConnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        result = unit.Gallon;
                        break;
                    case "GALLON_TO_LITRE":
                        unit.Litre = unit.Gallon * 1000;
                        sqlcommand.Parameters.AddWithValue("@liter", unit.Litre);
                        sqlcommand.Parameters.AddWithValue("@gallon", unit.Gallon);
                        sqlcommand.Parameters.AddWithValue("@milliliter", unit.Milliliter);
                        sqlcommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);


                        sqlConnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        result = unit.Litre;
                        break;
                    case "LITER_TO_MILILITRE":
                        unit.Milliliter = unit.Litre * 1000;
                        sqlcommand.Parameters.AddWithValue("@liter", unit.Litre);
                        sqlcommand.Parameters.AddWithValue("@gallon", unit.Gallon);
                        sqlcommand.Parameters.AddWithValue("@milliliter", unit.Milliliter);
                        sqlcommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);


                        sqlConnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        result = unit.Milliliter;
                        break;
                    case "MILILITER_TO_LITER":
                        unit.Litre = unit.Milliliter / 1000;
                        sqlcommand.Parameters.AddWithValue("@liter", unit.Litre);
                        sqlcommand.Parameters.AddWithValue("@gallon", unit.Gallon);
                        sqlcommand.Parameters.AddWithValue("@milliliter", unit.Milliliter);
                        sqlcommand.Parameters.AddWithValue("@unitOption", unit.UnitOption);


                        sqlConnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        result = unit.Litre;
                        break;
                    default:
                        result = new Exception("An Error Accour:");
                        break;


                }
                return result;
            }
            catch (Exception e)
            {

                throw new Exception("An Error Accured:" + e);
            }
        }
    }
}
