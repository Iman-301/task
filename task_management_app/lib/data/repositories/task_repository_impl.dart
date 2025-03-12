import 'package:task_management_app/data/models/task_model.dart';
import 'package:task_management_app/data/services/api_service.dart';
import 'package:task_management_app/domain/repositories/task_repository.dart';

class  TaskRepositoryImpl implements TaskRepository{
  final ApiService _apiService=ApiService();

  @override
  Future<List<TaskModel>> fetchTasks() async {
    final response=await _apiService.getTasks();
    return (response.data as List).map((e)=>TaskModel.fromJson(e)).toList();
  }
  @override
  Future<TaskModel> fetchTask(String id) async{
    final response=await _apiService.getTask(id);
    return TaskModel.fromJson(response.data);

  }

  @override
  Future<void> createTask(TaskModel task) async{
    await _apiService.createTask(task.toJson());

  }
  @override
  Future<void> updateTask(TaskModel task) async{
    await _apiService.updateTask(task.id,task.toJson());
  }
  @override

  Future<void> deleteTask(String id) async{
    await _apiService.deleteTask(id);
  }
}