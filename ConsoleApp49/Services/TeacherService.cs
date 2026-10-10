using ConsoleApp49.Models;
using ConsoleApp49.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49.Services;

public class TeacherService
{
    private readonly IUnitOfWork _unitOfWork;

    public TeacherService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task TransactionTeacherOperation(Teacher teacherToAdd, Teacher teacherToUpdate)
    {
        if (teacherToUpdate == null || teacherToAdd == null) return;

        await _unitOfWork.BeginTransactionAsync();
        try
        {

            await _unitOfWork.Teachers.AddAsync(teacherToAdd);
            await _unitOfWork.Teachers.UpdateAsync(teacherToUpdate);

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
