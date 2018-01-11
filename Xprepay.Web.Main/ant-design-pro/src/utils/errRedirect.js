import { routerRedux } from 'dva/router';

export function* checkResponse(obj) {
    const { put, response } = obj;
    if (response.status === 401) {
        yield put(routerRedux.push("../user/login"));
    }
    if (response.status === 403) {
        yield put(routerRedux.push("../exception/403"));
    }
    if (response.status === 404) {
        yield put(routerRedux.push("../exception/404"));
    }
    if (response.status >= 500) {
        yield put(routerRedux.push("../exception/500"));
    }
}