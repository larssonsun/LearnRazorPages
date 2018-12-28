using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

public class CustomPageRouteModelConvention : IPageRouteModelConvention
{
    // The route template information for each page is stored in a PageRouteModel class.
    //  One PageRouteModel class is created for each navigable Razor Page at application startup
    public void Apply(PageRouteModel model)
    {

        foreach (var selector in model.Selectors.ToList())
        {
            var template = selector.AttributeRouteModel.Template;


            // Console.WriteLine(model.RelativePath);
            // Console.WriteLine(template);
            // Console.WriteLine("---------------------------------------");

            //now i change the template "MyPages/_6_3_CustomPageRouteConv" to "Fukin"
            if (template == "MyPages/_6_3_CustomPageRouteConv/{handler?}")
            {
                selector.AttributeRouteModel.Template = "Fukin/{handler?}";
            }

        }

        //following code will add the original Template to path "/MyPages/_6_3_CustomPageRouteConv.cshtml"
        if (model.RelativePath == "/Pages/MyPages/_6_3_CustomPageRouteConv.cshtml")
        {
            model.Selectors.Add(new SelectorModel()
            {
                AttributeRouteModel = new AttributeRouteModel()
                {
                    Template = "/MyPages/_6_3_CustomPageRouteConv/{handler?}"
                }
            });
        };
    }
}