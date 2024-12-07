using MachineFeed.Dao;

namespace MachineFeed.Dal {
    public interface IMachineDal {
        MachineDetails getMachineDetails(int machineId);
        List<Repair> getRepairs(int machineId);
        List<Session> getSessions(int machineId);

    }
}
