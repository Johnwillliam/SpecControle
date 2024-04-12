using System.Drawing;
using System.Windows.Forms;

namespace Logic.Business
{
    public static class DataGridObjectsUtility
    {
        public static int ParseIntValue(List<DataGridViewRow> rows, string fieldName)
        {
            var cell = GetCellByDescription(rows, fieldName);
            if (cell != null && int.TryParse(cell.Value?.ToString(), out int value))
            {
                return value;
            }
            return 0;
        }

        public static int? ParseNullableIntValue(List<DataGridViewRow> rows, string fieldName)
        {
            var cell = GetCellByDescription(rows, fieldName);
            if (cell != null && int.TryParse(cell.Value?.ToString(), out int value))
            {
                return value;
            }
            return null;
        }

        public static decimal? ParseNullableDecimalValue(List<DataGridViewRow> rows, string fieldName)
        {
            var cell = GetCellByDescription(rows, fieldName);
            if (cell != null && decimal.TryParse(cell.Value?.ToString(), out decimal value))
            {
                return value;
            }
            return null;
        }

        public static string ParseStringValue(List<DataGridViewRow> rows, string description)
        {
            var cell = GetCellByDescription(rows, description);
            return cell?.Value?.ToString() ?? "";
        }

        public static DataGridViewCell GetCellByDescription(List<DataGridViewRow> rows, string description)
        {
            return rows.FirstOrDefault(x => x.Cells["Description"].Value.ToString().Equals(description))?.Cells["Value"];
        }

        public static void SetRowReadOnlyAndColor(DataGridViewRow row, bool isReadOnly)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ReadOnly = isReadOnly;
                cell.Style.BackColor = isReadOnly ? Color.LightGray : Color.White;
            }
        }

        public static int[] ParseSlashSeparatedIntValues(List<DataGridViewRow> rows, string fieldName)
        {
            var cell = GetCellByDescription(rows, fieldName);
            if (cell?.Value != null)
            {
                return cell.Value.ToString().Split('/').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();
            }
            return Array.Empty<int>();
        }
    }
}
