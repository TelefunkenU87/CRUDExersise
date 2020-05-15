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
                new Assignment { AssignmentId = 1, EmployeeId = 1, ClientName = "North Star Shipping", Role = "Lead", StartDate = new DateTime(2018, 01, 01), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { AssignmentId = 2, EmployeeId = 2, ClientName = "Ink and Block Press", Role = "Sales", StartDate = new DateTime(2018, 04, 05), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { AssignmentId = 3, EmployeeId = 3, ClientName = "Cottage Industry Inc", Role = "Shipping", StartDate = new DateTime(2018, 07, 10), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { AssignmentId = 4, EmployeeId = 4, ClientName = "Lisa's lemonade", Role = "Customer Relations", StartDate = new DateTime(2018, 10, 15), EndDate = new DateTime(2020, 05, 15) },
                new Assignment { AssignmentId = 5, EmployeeId = 5, ClientName = "The Law Offices of Bob Loblaw", Role = "Legal", StartDate = new DateTime(2018, 12, 20), EndDate = new DateTime(2020, 05, 15) }
            };
        }
        public Assignment Add(Assignment newAssignment)
        {
            if (_assignments.Count != 0)
            {
                newAssignment.AssignmentId = _assignments.Max(a => a.AssignmentId) + 1;
            }
            else
            {
                newAssignment.AssignmentId = 1;
            }
            _assignments.Add(newAssignment);
            return newAssignment;
        }

        public IEnumerable<Assignment> AllAssignments()
        {
            return _assignments;
        }

        public int Commit()
        {
            return 0;
        }

        public Assignment Delete(int assignmentId)
        {
            var assignment = _assignments.FirstOrDefault(a => a.AssignmentId == assignmentId);
            if (assignment != null)
            {
                _assignments.Remove(assignment);
            }
            return assignment;
        }

        public Assignment GetAssignmentById(int assignmentId)
        {
            return _assignments.SingleOrDefault(a => a.AssignmentId == assignmentId);
        }

        public IEnumerable<Assignment> GetAssignmentByName(string name)
        {
            return _assignments.Where(a => string.IsNullOrEmpty(name) || a.ClientName.StartsWith(name));
        }

        public Assignment Update(Assignment updatedAssignment)
        {
            var assignment = _assignments.SingleOrDefault(a => a.AssignmentId == updatedAssignment.AssignmentId);
            if (assignment != null)
            {
                assignment.EmployeeId = updatedAssignment.EmployeeId;
                assignment.ClientName = updatedAssignment.ClientName;
                assignment.Role = updatedAssignment.Role;
                assignment.StartDate = updatedAssignment.StartDate;
                assignment.EndDate = updatedAssignment.EndDate;
            }
            return assignment;
        }
    }
}
