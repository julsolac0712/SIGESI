Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
                        "~/Scripts/WebForms/WebForms.js",
                        "~/Scripts/WebForms/WebUIValidation.js",
                        "~/Scripts/WebForms/MenuStandards.js",
                        "~/Scripts/WebForms/Focus.js",
                        "~/Scripts/WebForms/GridView.js",
                        "~/Scripts/WebForms/DetailsView.js",
                        "~/Scripts/WebForms/TreeView.js",
                        "~/Scripts/WebForms/WebParts.js"))

        ' Order is very important for these files to work, they have explicit dependencies
        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

        ' Use the Development version of Modernizr to develop with and learn from. Then, when you’re
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"))

        ScriptManager.ScriptResourceMapping.AddDefinition("respond", New ScriptResourceDefinition() With {
                .Path = "~/Scripts/respond.min.js",
                .DebugPath = "~/Scripts/respond.js"})

        'Status messages
        bundles.Add(New ScriptBundle("~/bundles/status-messages").Include(
                    "~/Scripts/Custom/status-messages.js"))

        'Bootstrap
        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js"))

        'Bootstrap datetimepicker
        bundles.Add(New StyleBundle("~/Content/bootstrap-datetimepicker").Include(
            "~/Scripts/Contrib/bootstrap-datetime-picker/css/bootstrap-datetimepicker.min.css"))
        bundles.Add(New ScriptBundle("~/bundles/bootstrap-datetimepicker").Include(
            "~/Scripts/moment-with-locales.js", "~/Scripts/Contrib/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js", "~/Scripts/Custom/bootstrap-datetimepicker-init.js"))

        'CKEditor
        bundles.Add(New ScriptBundle("~/bundles/CKEditor").Include(
                    "~/Scripts/Contrib/ckeditor/ckeditor.js", "~/Scripts/Custom/ckeditor-init.js"))

        'Chosen JQuery
        bundles.Add(New ScriptBundle("~/bundles/Chosen").Include(
                    "~/Scripts/Contrib/chosen/chosen.jquery.min.js",
                    "~/Scripts/Custom/chosen-init.js"))

        bundles.Add(New StyleBundle("~/Content/chosen").Include(
                "~/Scripts/Contrib/chosen/chosen.min.css"))

        'Select2
        bundles.Add(New ScriptBundle("~/bundles/select2").Include(
            "~/Scripts/Contrib/select2/js/select2.full.min.js", "~/Scripts/Custom/select2-init.js"))
        bundles.Add(New StyleBundle("~/Content/select2").Include(
            "~/Scripts/Contrib/select2/css/select2.min.css"))

        'Floating labels
        bundles.Add(New ScriptBundle("~/bundles/floating-labels").Include(
                "~/Scripts/Custom/floating-labels.js"))

        'Form validator
        bundles.Add(New ScriptBundle("~/bundles/form-validator").Include(
                "~/Scripts/Contrib/form-validator/jquery.form-validator.min.js"))
        bundles.Add(New StyleBundle("~/Content/form-validator").Include(
            "~/Scripts/Contrib/form-validator/theme-default.css"))

        ' jquery
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-3.3.1.js", "~/Scripts/jquery-3.3.1.min.js"))

        'JQUERY UI
        bundles.Add(New ScriptBundle("~/bundles/jquery-ui").Include(
                    "~/Scripts/jquery-ui-1.12.1.min.js",
                    "~/Scripts/jquery-ui-datepicker-es.js",
                    "~/Scripts/Custom/datepicker-init.js"))
        'File Input
        bundles.Add(New ScriptBundle("~/bundles/bootstrap-file-selector-js").Include(
            "~/Scripts/Contrib/bootstrap-file-input/js/plugins/canvas-to-blob.min.js",
            "~/Scripts/Contrib/bootstrap-file-input/js/fileinput.min.js",
            "~/Scripts/Contrib/bootstrap-file-input/js/fileinput_locale_es.js",
            "~/Scripts/Custom/file-picker-init.js"))

        bundles.Add(New StyleBundle("~/bundles/bootstrap-file-selector-css").Include(
                    "~/Scripts/Contrib/bootstrap-file-input/css/fileinput.min.css"))
        'Modals
        bundles.Add(New ScriptBundle("~/bundles/modals").Include(
                    "~/Scripts/Custom/modal-init.js"))

        'HighMaps - HighCharts
        bundles.Add(New ScriptBundle("~/bundles/highcharts").Include(
                    "~/Scripts/Contrib/highcharts/js/highcharts.js",
                    "~/Scripts/Contrib/highcharts/js/highcharts-3d.js",
                    "~/Scripts/Contrib/highcharts/js/modules/data.js",
                    "~/Scripts/Contrib/highcharts/js/modules/drilldown.js",
                    "~/Scripts/Contrib/highcharts/js/modules/exporting.js"))

        'Propios de app
        bundles.Add(New ScriptBundle("~/bundles/notification-manager").Include(
                    "~/Scripts/Custom/notification-manager.js"))

        bundles.Add(New ScriptBundle("~/bundles/app-specific").Include(
                    "~/Scripts/Custom/app-specific.js"))

    End Sub
End Class
