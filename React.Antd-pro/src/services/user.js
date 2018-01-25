import request from '../utils/request';

// const host="http://192.168.1.83:8089";    
const host = "http://localhost:6832";


export async function query() {
  return request('/api/users');
}

export async function queryCurrent() {
  return request('/api/currentUser');
}

export async function userSearch(payload) {
  console.log(payload)
  return request(host + '/management/user/search', {
    method: 'POST',
    body: payload,
  })
}

export async function add(payload) {
  return request(host + '/management/user/add', {
    method: 'POST',
    body: payload,
  })
}
export async function index() {
  return request(host + '/management/user/index', {
    method: 'POST',
  })
}
export async function update(payload) {
  return request(host + '/management/user/updateadmin', {
    method: 'POST',
    body: payload,
  })
}
export async function changeDelflag(payload) {
  return request(host + '/management/user/delflag', {
    method: 'POST',
    body: payload
  })
}

export async function resetPassword(payload) {
  return request(host + '/management/user/resetPassword', {
    method: 'POST',
    body: payload
  })
}
