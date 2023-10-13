using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo.Models.Requests
{
    // https://labs.ig.com/rest-trading-api-reference/service-detail?id=693
    public class CreateWorkingOrderRequest
    {
        [RegularExpression("[A-Z]{3}")]
        public string currencyCode { get; set; } = string.Empty;

        [RegularExpression("[A-Za-z0-9_\\-]{1,30}")]
        public string? dealReference { get; set; } = string.Empty;

        public Direction direction { get; set; }

        public string epic { get; set; } = string.Empty;

        [RegularExpression("(\\d{2}-)?[A-Z]{3}-\\d{2}|-|DFB")]
        public string expiry { get; set; } = string.Empty;

        [RegularExpression("(\\d{4}/\\d{2}/\\d{2} \\d{2}:\\d{2}:\\d{2}|\\d*)")]
        public string? goodTillDate { get; set; }

        public bool guaranteedStop { get; set; }

        public decimal level { get; set; }

        public decimal? limitDistance { get; set; }

        public decimal? limitLevel { get; set; }

        [Range(0, 999999999999.9999)] // 限制小數點後最多12位
        public decimal size { get; set; }

        public decimal? stopDistance { get; set; }

        public decimal? stopLevel { get; set; }

        public TimeInForce timeInForce { get; set; }

        public WorkingOrderType type { get; set; }
    }

    public enum Direction
    {
        BUY,
        SELL
    }

    public enum TimeInForce
    {
        GOOD_TILL_CANCELLED, 
        GOOD_TILL_DATE    
    }

    public enum WorkingOrderType
    {
        LIMIT, 
        STOP 
    }
}
