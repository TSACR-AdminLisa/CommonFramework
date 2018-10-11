using Common.Validations.Actions;
using Common.Validations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validations.Objects
{
    public abstract class DataTypeValidation: BaseData 
    {

        protected IDataValidation impDataVal;

        #region Constructors

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="paramDataVariable">
        /// this parameters contains the data for a given variable an assignes it to the global 
        /// variable dataVariable for further validations inside this class
        /// </param>
        public DataTypeValidation(object paramDataVariable) : base(paramDataVariable)
        {
            dataVariable = paramDataVariable;
            impDataVal = new DataValidation(paramDataVariable);
        }

        #endregion


        #region Class-Functions

            #region Class-Int-DataType-Validations

            /// <summary>
            /// this function validates if a given variable is datatype.Short and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Short
            /// </returns>
            public bool ValidateIsShortValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Int16.TryParse(dataVariable.ToString(), out short number);
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is datatype.UShort and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.UShort
            /// </returns>
            public bool ValidateIsUShortValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return UInt16.TryParse(dataVariable.ToString(), out ushort number);
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is datatype.Int and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Int
            /// </returns>
            public bool ValidateIsIntValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Int32.TryParse(dataVariable.ToString(), out int number);
                else
                    return false;
            
            }

            /// <summary>
            /// this function validates if a given variable is datatype.UInt and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.UInt
            /// </returns>
            public bool ValidateIsUIntValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return UInt32.TryParse(dataVariable.ToString(), out uint number);
                else
                    return false;

            }

            /// <summary>
            /// this function validates if a given variable is datatype.Long and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Long
            /// </returns>
            public bool ValidateIsLongValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Int64.TryParse(dataVariable.ToString(), out long number);
                else
                    return false;            
            }

            /// <summary>
            /// this function validates if a given variable is datatype.ULong and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.ULong
            /// </returns>
            public bool ValidateIsULongValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return UInt64.TryParse(dataVariable.ToString(), out ulong number);
                else
                    return false;
            }

            #endregion

            #region Class-Text-DataType-Validations

            /// <summary>
            /// this function validates if a given variable is datatype.Char and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Char
            /// </returns>
            public bool ValidateIsCharValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Char.TryParse(dataVariable.ToString(), out char text);
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is datatype.String and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.String
            /// </returns>
            public bool ValidateIsStringValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    try
                    {
                        string text = dataVariable.ToString();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                else
                    return false;
            }

            #endregion

            #region Class-Byte-DataType-Validations

            /// <summary>
            /// this function validates if a given variable is datatype.Byte and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Byte
            /// </returns>
            public bool ValidateIsByteValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Byte.TryParse(dataVariable.ToString(), out byte varByte);
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is datatype.SByte and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.SByte
            /// </returns>
            public bool ValidateIsSByteValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return SByte.TryParse(dataVariable.ToString(), out sbyte varSByte);
                else
                    return false;
            }

            #endregion

            #region Class-Boolean-DataType-Validations

            /// <summary>
            /// this function validates if a given variable is datatype.Bool and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Bool
            /// </returns>
            public bool ValidateIsBooleanValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Boolean.TryParse(dataVariable.ToString(), out bool varFlag);
                else
                    return false;
            }

            #endregion

            #region Class-Decimal-DataType-Validations

            /// <summary>
            /// this function validates if a given variable is datatype.Decimal and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Decimal
            /// </returns>
            public bool ValidateIsDecimalValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Decimal.TryParse(dataVariable.ToString(), out decimal number);
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is datatype.Double and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Double
            /// </returns>
            public bool ValidateIsDoubleValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return Double.TryParse(dataVariable.ToString(), out double number);
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is datatype.Float and returns true or false
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL or is not DataType.Float
            /// </returns>
            public bool ValidateIsFloatValue()
            {
                if (!impDataVal.IsVarDataContentEmptyOrNull())
                    return float.TryParse(dataVariable.ToString(), out float number);
                else
                    return false;
            }

            #endregion

        #endregion

    }
}
