import 'package:task_management_app/data/models/task_model.dart';

abstract class TaskRepository {
  Future<List<TaskModel>> fetchTasks();
  Future<TaskModel> fetchTask(String id);
  Future<void> createTask(TaskModel task);
  Future<void> updateTask(TaskModel task);
  Future<void> deleteTask(String id);
}
