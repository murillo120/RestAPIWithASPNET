using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumber(firstNumber) && IsNumber(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum);
            }
            return BadRequest("invalid input");
        }

        [HttpGet("Sub/{firstNumber}/{secondNumber}")]
        public IActionResult SubGet(string firstNumber, string secondNumber)
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(sub);
        }

        [HttpGet("Multiply/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiply(string firstNumber, string secondNumber)
        {
            var multiply = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(multiply);
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult DivGet(string firstNumber, string secondNumber)
        {
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(div);
        }

        [HttpGet("Average/{firstNumber}/{secondNumber}")]
        public IActionResult AverageGet(string firstNumber, string secondNumber)
        {
            var average = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

            return Ok(average);
        } 

        [HttpGet("Square/{firstNumber}")]
        public IActionResult SquareGet(string firstNumber)
        {
            var square = Math.Sqrt((double) ConvertToDecimal(firstNumber));

            return Ok(square);
        }

        private bool IsNumber(string strnumber)
        {

            bool isNumber = double.TryParse(strnumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out _);


            return isNumber;

        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalvalue;

            if(decimal.TryParse(number, out decimalvalue))
            {
                return decimalvalue;
            }

            return 0;
        }
    }
}
