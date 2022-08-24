namespace CodeHelper.API.Awin
{
    [System.AttributeUsage(System.AttributeTargets.Field |
                       System.AttributeTargets.Property)
    ]
    public class AwinAttribute : System.Attribute
    {
        #region Properties
        public string AwinField { get; set; } = "";
        #endregion

        #region Constructors
        public AwinAttribute() { }
        /// <param name="fieldName">string: Name of the field in the database. (Aliaseses are alloweed)</param>
        /// <param name="saveToDB">bool: indicates if the field shoud be used in the Save function</param>
        public AwinAttribute(string awinFieldname)
        {
            this.AwinField = awinFieldname;
        }
        #endregion
    }
}