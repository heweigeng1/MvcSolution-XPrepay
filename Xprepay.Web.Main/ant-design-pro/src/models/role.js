import { routerRedux } from 'dva/router';
//获取接口
import { getRoles, roleSearch } from '../services/testOne';
import Search from '../../node_modules/.3.0.2@antd/lib/transfer/search';

export default {
    namespace: 'role',

    state: {
        list: [],
        loading: true,
    },
    effects: {
        *getRoles({ payload }, { call, put }) {
            const response = yield call(getRoles);
            console.log(response);
            yield put({
                type: 'loadList',
                payload: response,
            })
        },
        *searchRole({ payload }, { call, put }) {
            console.log(payload)
            //带参数的请求
            const response = yield call(roleSearch,payload);
            yield put({
                type: 'loadList',
                payload: response,
            })
        }
    },
    reducers: {
        loadList(state, { payload }) {
            console.log(payload)
            return {
                ...state,
                list: payload,
                loading: false,
            }
        }
    }
}