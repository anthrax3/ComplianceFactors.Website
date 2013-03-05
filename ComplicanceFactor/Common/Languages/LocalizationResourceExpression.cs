using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.CodeDom;
using System.Web.UI;
using ComplicanceFactor.Common.Languages;
using System.Web.Compilation;
using System.ComponentModel;

namespace ComplicanceFactor
{
    [ExpressionPrefix("LocalizationResourceExpression")]
    [ExpressionEditor("LocalizationResourceExpressionEditor")]
    public class LocalizationResourceExpressionBuilder : ExpressionBuilder
    {
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            Type type1 = entry.DeclaringType;
            PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(type1)[entry.PropertyInfo.Name];
            CodeExpression[] expressionArray1 = new CodeExpression[3];
            expressionArray1[0] = new CodePrimitiveExpression(entry.Expression.Trim());
            expressionArray1[1] = new CodeTypeOfExpression(type1);
            expressionArray1[2] = new CodePrimitiveExpression(entry.Name);

            return new CodeCastExpression(descriptor1.PropertyType, new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetEvalLocalizationLabel", expressionArray1));

        }
        public static object GetEvalLocalizationLabel(string expression, Type target, string entry)
        {
            return LocalResources.GetLocalizationResourceLabelText(expression);
        }
    }
}
