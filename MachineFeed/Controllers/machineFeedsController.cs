using MachineFeed.Handler;
using MachineFeed.Projection;
using Microsoft.AspNetCore.Mvc;


namespace MachineFeed.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class machineFeedsController : ControllerBase {

        private readonly IMachineHandler machineHandler;

        public machineFeedsController(IMachineHandler machineHandler) {
            this.machineHandler = machineHandler;
        }

        [HttpGet("{machineId}")]
        public List<MachineFeedDetails> Get( int machineId) {
            var res = machineHandler.getMachineFeed(machineId,null);
            return res;
        }

        [HttpGet("session/{machineId}")]
        public List<MachineFeedDetails> GetSessions(int machineId) {
            var res = machineHandler.getMachineFeed(machineId,"S");
            return res;
        }

        [HttpGet("repair/{machineId}")]
        public List<MachineFeedDetails> GetRepairs(int machineId) {
            var res = machineHandler.getMachineFeed(machineId, "R");
            return res;
        }
    }
}
