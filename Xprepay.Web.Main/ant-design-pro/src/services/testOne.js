import request from '../utils/request';

//测试接口
export async function testone() {
  return request('/management/role/login');
}
