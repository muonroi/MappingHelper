using MappingHelper.Helper;

namespace MappingHelper
{
    public partial class Home : Form
    {
        [GeneratedRegex(@"\[\s*[^\]]+\]")]
        private static partial Regex AttributePattern();

        [GeneratedRegex(@"\b(public|protected|internal|private)\s+")]
        private static partial Regex AccessModifierPattern();

        [GeneratedRegex(@"\{\s*get;\s*set;\s*\}")]
        private static partial Regex GetSetPattern();

        [GeneratedRegex(@"^\s+$[\r\n]*", RegexOptions.Multiline)]
        private static partial Regex EmptyLinesPattern();

        [GeneratedRegex(@"public\s+class\s+\w+(\s*:\s*\w+)?\s*\{")]
        private static partial Regex ClassDeclarationPattern();

        [GeneratedRegex(@"message\s+\w+\s*\{")]
        private static partial Regex ProtoClassDeclarationPattern();

        [GeneratedRegex(@"\}")]
        private static partial Regex FinalBracePattern();

        [GeneratedRegex(@"//.*?$|/\*.*?\*/", RegexOptions.Singleline | RegexOptions.Multiline)]
        private static partial Regex CommentsPattern();

        [GeneratedRegex(@"\s*=\s*[^;]+;")]
        private static partial Regex DefaultValuesPattern();

        [GeneratedRegex(@"public\s+class\s+(\w+)(\s*:\s*\w+)?\s*\{")]
        private static partial Regex ClassNamePattern();

        [GeneratedRegex(@"message\s+(\w+)\s*\{")]
        private static partial Regex ProtoClassNamePattern();

        [GeneratedRegex(@"(optional|required|repeated)?\s*(\w+)\s+(\w+)\s*=\s*\d+;")]
        private static partial Regex ProtoFieldsPattern();

        [GeneratedRegex(@"public\s+(\w+)\s*\(\s*\)\s*{[^}]*}")]
        private static partial Regex ConstructorPattern();

        private static readonly string[] NewLineSeparators = ["\n", "\r"];

        private static readonly string[] SpaceSeparator = [" "];

        public Home()
        {
            InitializeComponent();
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string modelA = txtSource.Text;
                string modelB = txtDestination.Text;
                string mode = rdMM.Checked ? "MM" : "PM";
                string result = mode == "MM" ? ProcessModelToModel(modelA, modelB) : ProcessProtoToModel(modelA, modelB);

                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"An error occurred while processing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string ProcessModelToModel(string modelA, string modelB)
        {
            try
            {
                string cleanedModelA = CleanModel(modelA);
                string cleanedModelB = CleanModel(modelB);

                return MapModels(cleanedModelA, cleanedModelB, modelA, modelB);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error processing Model to Model mapping", ex);
            }
        }

        private static string ProcessProtoToModel(string proto, string model)
        {
            try
            {
                string cleanedProto = CleanProto(proto);
                string cleanedModel = CleanModel(model);

                return MapProtoToModel(cleanedProto, cleanedModel, proto, model);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error processing Proto to Model mapping", ex);
            }
        }

        public static string CleanModel(string model)
        {
            try
            {
                string cleanedModel = model
                    .Pipe(RemoveComments)
                    .Pipe(RemoveConstructors)
                    .Pipe(RemoveClassDeclaration)
                    .Pipe(RemoveAttribute)
                    .Pipe(RemoveAccessModifiers)
                    .Pipe(RemoveGetSet)
                    .Pipe(RemoveDefaultValues)
                    .Pipe(RemoveFinalBrace)
                    .Pipe(RemoveEmptyLines)
                    .Trim();

                return cleanedModel;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error cleaning model", ex);
            }
        }

        public static string MapModels(string cleanedModelA, string cleanedModelB, string originalModelA, string originalModelB)
        {
            try
            {
                Dictionary<string, string> propertiesA = ExtractProperties(cleanedModelA);
                Dictionary<string, string> propertiesB = ExtractProperties(cleanedModelB);

                string classNameA = ExtractClassNameFromModel(originalModelA).ToLower();
                string classNameB = ExtractClassNameFromModel(originalModelB);

                List<string> commonProperties = propertiesA.Keys.Intersect(propertiesB.Keys).ToList();

                List<string> mapping = commonProperties
                    .Select(property => $"{property} = {classNameA}.{property}")
                    .ToList();

                string mappingResult = $"{classNameB} {classNameB.ToLower()} = new {classNameB}\n{{\n    " +
                                       string.Join(",\n    ", mapping) + "\n};";

                return mappingResult;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping models", ex);
            }
        }

        private static string CleanProto(string proto)
        {
            try
            {
                string cleanedProto = proto
                    .Pipe(RemoveComments)
                    .Pipe(RemoveProtoClassDeclaration)
                    .Pipe(RemoveEmptyLines)
                    .Trim();

                return cleanedProto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error cleaning proto", ex);
            }
        }

        private static string MapProtoToModel(string cleanedProto, string cleanedModel, string originalProto, string originalModel)
        {
            try
            {
                Dictionary<string, (string type, bool isRepeated)> fields = ExtractProtoFields(cleanedProto);
                Dictionary<string, string> properties = ExtractProperties(cleanedModel);

                string classNameProto = ExtractProtoClassNameFromModel(originalProto).ToLower();
                string classNameModel = ExtractClassNameFromModel(originalModel);

                List<string> commonProperties = fields.Keys.Intersect(properties.Keys).ToList();

                List<string> mapping = commonProperties.Select(property =>
                {
                    (string type, bool isRepeated) = fields[property];
                    return isRepeated
                        ? $"{property} = new List<{properties[property]}>(), /* mapping logic */"
                        : type switch
                        {
                            "google.protobuf.Timestamp" or "Timestamp" => $"{property} = {classNameProto}.{property}.ToDateTime()",
                            _ when IsCustomMessageType(type) => $"{property} = new {type}(), /* mapping object */ ",
                            _ => $"{property} = {classNameProto}.{property}"
                        };
                }).ToList();

                string mappingResult = $"{classNameModel} {classNameModel.ToLower()} = new {classNameModel}\n{{\n    " +
                                       string.Join(",\n    ", mapping) + "\n};";

                return mappingResult;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping proto to model", ex);
            }
        }

        private static bool IsCustomMessageType(string type)
        {
            string[] standardTypes = ["string", "int32", "int64", "uint32", "uint64", "bool", "float", "double", "bytes"];
            return !standardTypes.Contains(type);
        }

        private static string ExtractProtoClassNameFromModel(string proto)
        {
            Match match = ProtoClassNamePattern().Match(proto);
            return match.Success ? match.Groups[1].Value : "UnknownProto";
        }

        private static Dictionary<string, (string type, bool isRepeated)> ExtractProtoFields(string proto)
        {
            MatchCollection matches = ProtoFieldsPattern().Matches(proto);

            return matches.Cast<Match>().ToDictionary(
                match => ConvertToPascalCase(match.Groups[3].Value),
                match => (match.Groups[2].Value, match.Groups[1].Value == "repeated")
            );
        }

        private static string ConvertToPascalCase(string snakeCase)
        {
            return string.Concat(snakeCase.Split('_').Select(word => char.ToUpperInvariant(word[0]) + word[1..].ToLowerInvariant()));
        }

        private static string ExtractClassNameFromModel(string model)
        {
            Match match = ClassNamePattern().Match(model);
            return match.Success ? match.Groups[1].Value : "UnknownClass";
        }

        public static Dictionary<string, string> ExtractProperties(string model)
        {
            return model
                .Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim().Split(SpaceSeparator, StringSplitOptions.RemoveEmptyEntries))
                .Where(parts => parts.Length >= 2)
                .ToDictionary(parts => parts[1].Trim(';'), parts => parts[0]);
        }

        // Các phương thức loại bỏ regex để làm sạch model và proto
        private static string RemoveComments(string input)
        {
            return CommentsPattern().Replace(input, "");
        }

        private static string RemoveConstructors(string input)
        {
            return ConstructorPattern().Replace(input, "");
        }

        private static string RemoveClassDeclaration(string input)
        {
            return ClassDeclarationPattern().Replace(input, "");
        }

        private static string RemoveProtoClassDeclaration(string input)
        {
            return ProtoClassDeclarationPattern().Replace(input, "");
        }

        private static string RemoveAttribute(string input)
        {
            return AttributePattern().Replace(input, "");
        }

        private static string RemoveAccessModifiers(string input)
        {
            return AccessModifierPattern().Replace(input, "");
        }

        private static string RemoveGetSet(string input)
        {
            return GetSetPattern().Replace(input, "");
        }

        private static string RemoveDefaultValues(string input)
        {
            return DefaultValuesPattern().Replace(input, ";");
        }

        private static string RemoveFinalBrace(string input)
        {
            return FinalBracePattern().Replace(input, "");
        }

        private static string RemoveEmptyLines(string input)
        {
            return EmptyLinesPattern().Replace(input, "");
        }
    }
}