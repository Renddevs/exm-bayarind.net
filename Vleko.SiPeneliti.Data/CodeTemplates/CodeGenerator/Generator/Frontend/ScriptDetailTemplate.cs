﻿using Vleko.Bayarind.Data.CodeGenerator;
using EntityFrameworkCore.Scaffolding.Handlebars;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vleko.Bayarind.Data.CodeGenerator.Generator
{
    public partial class CodeTemplate
    {
        #region Template
        public static (bool success, string key, object val) GenerateScriptDetail(string current_namespace, IModel model, Microsoft.Extensions.Options.IOptions<HandlebarsScaffoldingOptions> _options, List<SettingExcludeTableCodeGeneratorObject> exclude)
        {
            var sb = new Microsoft.EntityFrameworkCore.Infrastructure.IndentedStringBuilder();
            string project_name = current_namespace + "Data";
            string project_path = Directory.GetCurrentDirectory().Replace(project_name, "");
            string template_path = Path.Combine(project_path, current_namespace + @"Data\CodeTemplates\CodeGenerator\Template\Frontend\ScriptsDetail.hbs");
            if (!File.Exists(template_path))
            {
                return (false, null, null);
            }
            var code_template = File.ReadAllText(template_path);
            List<string> exclude_attributes = new List<string>()
            {
                "id",
                "createby",
                "create_by",
                "createdby",
                "created_by",
                "createdate",
                "create_date",
                "updateby",
                "update_by",
                "updatedby",
                "updated_by",
                "updatedate",
                "update_date"
            };
            using (sb.Indent())
            using (sb.Indent())
            {
                foreach (var entityType in model.GetScaffoldEntityTypes(_options.Value))
                {

                    bool create_code = true;
                    if (exclude != null && exclude.Count() > 0)
                    {
                        var exclude_table = exclude.Where(d => d.TableName.ToLower() == entityType.Name.ToLower()).FirstOrDefault();
                        if (exclude_table != null && !exclude_table.Service)
                            create_code = false;
                    }
                    if (create_code)
                    {
                        string name = RemovePrefix(entityType.Name);
                        string schema = GetPrefix(entityType.Name);
                        string model_name = entityType.Name;
                        var list_properties = entityType.GetProperties();

                        string target_path = Path.Combine(project_path, current_namespace + $@"Data\Generated\Frontend\Core\{schema}\{name}\Scripts");

                        if (!Directory.Exists(target_path))
                            Directory.CreateDirectory(target_path);

                        var code = code_template;
                        string code_file = Path.Combine(target_path, $"detail.js");

                        code = code.Replace("{{name}}", name);

                        string attributes = "";
                        foreach (var d in list_properties)
                        {
                            if (d.IsPrimaryKey())
                                continue;
                            if (!exclude_attributes.Contains(d.Name.ToLower()))
                            {
                                string tabular = "\t\t\t\t";
                                string att_name = FirstCharToLowerCase(d.Name);
                                string type = ParseType(d.ClrType);
                                string attribute = "";
                                switch (type)
                                {
                                    case "bool":
                                        attribute = tabular + @$"$('#Detail-{name}-{d.Name}').prop('checked', data.{att_name});";
                                        break;
                                    default:
                                        attribute = tabular + @$"$('#Detail-{name}-{d.Name}').val(data.{att_name});";
                                        break;
                                }
                                attributes += $"{attribute}" + Environment.NewLine;
                            }
                        }
                        code = code.Replace("{{attributes}}", attributes);
                        using (StreamWriter outputFile = new StreamWriter(code_file))
                        {
                            outputFile.WriteLine(code);
                        }
                    }
                }
            }
            var onDTOGenerate = sb.ToString();
            return (true, "on-Services-Generate", onDTOGenerate);
        }
        #endregion
    }
}
