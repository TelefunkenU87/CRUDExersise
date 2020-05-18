using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class MockAssignmentRepository : IAssignmentRepository
    {
        List<Assignment> _assignments;
        public MockAssignmentRepository()
        {
            _assignments = new List<Assignment>()
            {
                new Assignment { ClientId = 1, EmployeeId = 1, Role = "Lead", StartDate = new DateTime(2018, 01, 01), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { ClientId = 2, EmployeeId = 2, Role = "Sales", StartDate = new DateTime(2018, 04, 05), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { ClientId = 3, EmployeeId = 3, Role = "Shipping", StartDate = new DateTime(2018, 07, 10), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { ClientId = 4, EmployeeId = 4, Role = "Customer Relations", StartDate = new DateTime(2018, 10, 15), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { ClientId = 5, EmployeeId = 5, Role = "Legal", StartDate = new DateTime(2018, 12, 20), EndDate = new DateTime(2020, 05, 15)}
            };
        }

        public Assignment Add(Assignment newAssignment)
        {
            _assignments.Add(newAssignment);
            return newAssignment;
        }

        public int Commit()
        {
            return 0;
        }

        public Assignment Delete(int clientId, int employeeId)
        {
            var assignment = _assignments.FirstOrDefault(a => a.ClientId == clientId && a.EmployeeId == employeeId);
            if (assignment != null)
            {
                _assignments.Remove(assignment);
            }
            return assignment;
        }

        public IEnumerable<Assignment> GetAllAssignments()
        {
            return _assignments;
        }

        public Assignment GetAssignment(int clientId, int employeeId)
        {
            return _assignments.SingleOrDefault(a => a.ClientId == clientId && a.EmployeeId == employeeId);
        }

        public List<Assignment> GetAssignmentsByEmployeeId(int employeeId)
        {
            return _assignments.Where(a => a.EmployeeId == employeeId).ToList();
        }

        public List<Assignment> GetAssignmentsByClientId(int clientId)
        {
            return _assignments.Where(a => a.ClientId == clientId).ToList();
        }

        public Assignment Update(Assignment updatedAssignment)
        {
            var assignment = _assignments.SingleOrDefault(a => a.ClientId == updatedAssignment.ClientId && a.EmployeeId == updatedAssignment.EmployeeId);
            if(assignment != null)
            {
                assignment.ClientId = updatedAssignment.ClientId;
                assignment.EmployeeId = updatedAssignment.EmployeeId;
                assignment.Role = updatedAssignment.Role;
                assignment.StartDate = updatedAssignment.StartDate;
                assignment.EndDate = updatedAssignment.EndDate;
            }
            return assignment;
        }
    }
}
