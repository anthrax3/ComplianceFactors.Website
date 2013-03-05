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

    [ExpressionPrefix("ResourceExpression")]
    [ExpressionEditor("ResourceExpressionEditor")]
    public class ResourceExpressionBuilder : ExpressionBuilder
    {

        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            Type type1 = entry.DeclaringType;
            PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(type1)[entry.PropertyInfo.Name];
            CodeExpression[] expressionArray1 = new CodeExpression[3];
            expressionArray1[0] = new CodePrimitiveExpression(entry.Expression.Trim());
            expressionArray1[1] = new CodeTypeOfExpression(type1);
            expressionArray1[2] = new CodePrimitiveExpression(entry.Name);

            return new CodeCastExpression(descriptor1.PropertyType, new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetEvalLabel", expressionArray1));

        }
        //public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        //{
        //    Type type1 = entry.DeclaringType;
        //    PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(type1)[entry.PropertyInfo.Name];
        //    CodeExpression[] expressionArray1 = new CodeExpression[3];
        //    expressionArray1[0] = new CodePrimitiveExpression(entry.Expression.Trim());
        //    expressionArray1[1] = new CodeTypeOfExpression(type1);
        //    expressionArray1[2] = new CodePrimitiveExpression(entry.Name);
        //    return new CodeCastExpression(descriptor1.PropertyType, new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetEvalText", expressionArray1));
        //}

        public static object GetEvalLabel(string expression, Type target, string entry)
        {
            string _name = expression;
            string _required = _name.Substring(_name.Length - 1, 1);
            if (_required == "^")
            {
                return LocalResources.GetLocaleResourceText(expression);

            }
            else
            {
                return LocalResources.GetLocaleResourceString(expression);
            }
        }
        public static object GetEvalText(string expression, Type target, string entry)
        {
            return LocalResources.GetLocaleResourceText(expression);
        }
        public static object GetEvalLocalizationLabel(string expression, Type target, string entry)
        {
            return LocalResources.GetLocalizationResourceLabelText(expression);
        }
    }
}

