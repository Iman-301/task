import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:task_management_app/presentation/providers/task_provider.dart';

class TaskListScreen extends ConsumerWidget{
  @override
  Widget build(BuildContext context,WidgetRef ref){
    final taskList=ref.watch(taskListProvider);

    return Scaffold(
      appBar: AppBar(title: Text('Tasks')),
      body: taskList.when(
        data: (tasks)=> ListView.builder(
          itemCount: tasks.length,
          itemBuilder: (context, index){
            final task=tasks[index];
            return ListTile(
              title: Text(task.title),
              subtitle: Text(task.description),
              trailing: Checkbox(value: task.isCompleted, onChanged: (bool? value) {
                ref.read(taskRepositoryProvider).updateTask(task.copyWith(isCompleted: value!));
              },),
            );
          }),
          loading: ()=>Center(child: CircularProgressIndicator(),),
          error: (err,stack)=>Center(child: Text('Error: $err'),),
      )
    );
  }
}