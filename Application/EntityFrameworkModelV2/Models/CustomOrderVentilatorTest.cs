namespace EntityFrameworkModelV2.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CustomOrderVentilatorTest
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CustomOrderVentilatorID { get; set; }
        public int? MeasuredVentilatorHighRPM { get; set; }
        public int? MeasuredVentilatorLowRPM { get; set; }
        public int? MeasuredMotorHighRPM { get; set; }
        public int? MeasuredMotorLowRPM { get; set; }
        public int? MeasuredBladeAngle { get; set; }
        public int? Cover { get; set; }
        public string MotorNumber { get; set; }
        public int? Weight { get; set; }
        public DateTime? Date { get; set; }
        public int? UserID { get; set; }
        [Precision(18, 2)]
        public decimal? I1High { get; set; }
        [Precision(18, 2)]
        public decimal? I1Low { get; set; }
        [Precision(18, 2)]
        public decimal? I2High { get; set; }
        [Precision(18, 2)]
        public decimal? I2Low { get; set; }
        [Precision(18, 2)]
        public decimal? I3High { get; set; }
        [Precision(18, 2)]
        public decimal? I3Low { get; set; }
        public int? BuildSize { get; set; }
        public bool Locked { get; set; }

        public virtual int IndexNumber => CustomOrderVentilator.CustomOrder.CustomOrderVentilators.SelectMany(x => x.CustomOrderVentilatorTests).ToList().IndexOf(this) + 1;
        public virtual string SerialNumber => $"{CustomOrderVentilator.CustomOrder.CustomOrderNumber}/{IndexNumber:000}/{CustomOrderVentilator.CustomOrder.CreateDate.GetValueOrDefault().Year}";
        public virtual CustomOrderVentilator CustomOrderVentilator { get; set; }
        public virtual User User { get; set; }
    }
}