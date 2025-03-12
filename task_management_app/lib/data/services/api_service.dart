import 'package:dio/dio.dart';

class ApiService{
  // might be 5000
final Dio _dio = Dio(BaseOptions(baseUrl: 'http://localhost:5187/api'));


  Future<Response> getTasks() async=>await _dio.get('/tasks');
  Future<Response> getTask(String id) async =>await _dio.get('/tasks/$id');
  Future<Response> createTask(Map<String, dynamic> data) async =>await  _dio.post('/tasks', data:data);
  Future <Response> updateTask(String id, Map<String,dynamic> data) async => await _dio.put('/tasks/$id', data: data);

  Future<Response> deleteTask(String id) async => await _dio.delete('/tasks/$id');


}

