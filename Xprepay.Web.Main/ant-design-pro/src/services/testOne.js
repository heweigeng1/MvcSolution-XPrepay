import request from '../utils/request';

//测试接口
export async function testone() {
  return request('http://localhost:6832/management/role/login');
}

export async function getRoles() {
  return request('http://localhost:6832/management/role/get')
}

export async function roleSearch(payload) {
  return request('http://localhost:6832/management/role/search', {
    method: 'POST',
    body: payload,
  });
}

export async function xlogin(payload) {
  return request('http://localhost:6832/management/account/login', {
    method: 'POST',
    body: payload,
  });
}
export async function ylogin() {
  return request('http://localhost:6832/api/account/login', {
    method: 'GET',
  });
}