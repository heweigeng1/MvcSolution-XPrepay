import request from '../utils/request';

export async function query() {
  return request('/api/users');
}

export async function queryCurrent() {
  return request('/api/currentUser');
}

export async function userSearch(payload) {
  return request('http://localhost:6832/management/user/search', {
    method: 'POST',
    body: payload,
  })
}
export async function add(payload) {
  return request('http://localhost:6832/management/user/add', {
    method: 'POST',
    body: payload,
  })
}

export async function index() {
  return request('http://localhost:6832/management/user/index', {
    method: 'GET',
  })
}

export async function resetPassword(payload) {
  return request('http://localhost:6832/management/user/resetPassword?id='+payload, {
    method: 'GET',
  })
}