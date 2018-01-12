import request from '../utils/request';

export async function query() {
  return request('/api/users');
}

export async function queryCurrent() {
  return request('/api/currentUser');
}

export async function search(params) {
  return request('http://localhost:6832/management/user/search', {
    method: 'Post',
    body: params,
  })
}
