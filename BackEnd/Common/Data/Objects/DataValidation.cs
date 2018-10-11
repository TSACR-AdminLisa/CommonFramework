using Common.Validations.Actions;
using Common.Validations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validations.Objects
{
    /// <summary>
    /// This class has the function for validating data content, and gives the programmer an
    /// easy task to add in his code
    /// </summary>
    public class DataValidation : BaseData, IDataValidation
    {

        #region Constructors

            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="paramDataVariable">
            /// this parameters contains the data for a given variable an assignes it to the global 
            /// variable dataVariable for further validations inside this class
            /// </param>
            public DataValidation(object paramDataVariable) : base(paramDataVariable)
            {
                dataVariable = paramDataVariable;
            }

        #endregion


        /// <summary>
        /// this section is use to declare class abstract methods
        /// </summary>
        #region ClassMethods

        ///empty section for now

        #endregion


        #region ClassFunctions

            /// <summary>
            /// this function validates if a given variable is null or not
            /// </summary>
            protected internal bool ValidateIsNull()
            {
                if (dataVariable == null)
                    return true;
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is DBNULL or not
            /// </summary>
            protected internal bool ValidateIsDBNull()
            {
                if (dataVariable is DBNull)
                    return true;
                else
                    return false;
            }

            /// <summary>
            /// this function validates if a given variable is Empty or not
            /// </summary>
            protected internal bool ValidateIsEmpty()
            {
                if (dataVariable.ToString() == String.Empty)
                    return true;
                else
                    return false;
            }

            /// <summary>
            /// Validates if a given variable contains null, empty o DBNULL value
            /// </summary>
            /// <returns>
            ///     true: if the variable has any of this asumptions
            ///     false: if the variable is not null and not empty and not DBNULL
            /// </returns>
            public bool IsVarDataContentEmptyOrNull()
            {
                try
                {
                    if (ValidateIsNull() || ValidateIsEmpty() || ValidateIsDBNull())
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    return true;
                }

            }

        #endregion


    }
}
