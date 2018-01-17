import { routerRedux } from 'dva/router';
import { checkResponse } from '../utils/errRedirect';
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
            const response = yield call(getRoles, { put });
            //是否正确返回数据.根据错误code 跳转页面
            yield call(checkResponse, { response, put });
            yield put({
                type: 'loadList',
                payload: response.Value,
            })
        },
        *searchRole({ payload }, { call, put }) {
            console.log(payload)
            //带参数的请求
            const response = yield call(roleSearch, payload);
            //是否正确返回数据.根据错误code 跳转页面
            yield call(checkResponse, { response, put });
            yield put({
                type: 'loadList',
                payload: response.Value,
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