namespace EntityFrameworkModelV2.Models
{
    using System;
    using System.Collections.Generic;
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
        public string? MotorNumber { get; set; }
        public int? Weight { get; set; }
        public DateTime? Date { get; set; }
        public int? UserID { get; set; }
        public decimal? I1High { get; set; }
        public decimal? I1Low { get; set; }
        public decimal? I2High { get; set; }
        public decimal? I2Low { get; set; }
        public decimal? I3High { get; set; }
        public decimal? I3Low { get; set; }
        public int? BuildSize { get; set; }

        public virtual CustomOrderVentilator CustomOrderVentilator { get; set; }
        public virtual User User { get; set; }
    }
}
