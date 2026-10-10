using ConsoleApp49.Models;
using ConsoleApp49.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Services;

public class StudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task TransactionStudentOperation(Student studentToAdd, Student studentToUpdate)
    {
        if (studentToAdd == null || studentToUpdate == null) return;

        await _unitOfWork.BeginTransactionAsync();
        try
        {

            await _unitOfWork.Students.AddAsync(studentToAdd);
            await _unitOfWork.Students.UpdateAsync(studentToUpdate);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            Console.WriteLine("Transaction Succesfully!");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            Console.WriteLine($"Transaction Failed: {ex.Message}");
        }
    }


}
