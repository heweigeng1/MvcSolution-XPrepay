import { routerRedux } from 'dva/router';
//获取接口
import { getRoles, roleSearch } from '../services/testOne';
import Search from '../../node_modules/.3.0.2@antd/lib/transfer/search';

export default {
    namespace: 'role',

    state: {
        data: {
            list: [],
            pagination: {},
        },
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
            //带参数的请求
            console.log(payload)
            const response = yield call(roleSearch, payload);
            console.log(response);
            yield put({
                type: 'loadList',
                payload: response,
            })
        }
    },
    reducers: {
        loadList(state, { payload }) {
            return {
                ...state,
                data: {
                    list: payload.Value,
                    pagination: {
                        total: payload.TotalCount,
                        pageSize: payload.PageSize,
                        current: payload.PageIndex,
                    }
                },
                loading: false,
            }
        }
    }
}