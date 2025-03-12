import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:task_management_app/data/models/task_model.dart';
import 'package:task_management_app/data/repositories/task_repository_impl.dart';

final taskRepositoryProvider = Provider<TaskRepositoryImpl>((ref) => TaskRepositoryImpl());

final taskListProvider = FutureProvider<List<TaskModel>>((ref) async {
  // here watch creates instanse of thr repoImplementation
  final repository = ref.watch(taskRepositoryProvider);
  return await repository.fetchTasks();
});
