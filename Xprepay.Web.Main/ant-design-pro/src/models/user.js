import { query as queryUsers, queryCurrent, search, index } from '../services/user';
import { checkResponse } from '../utils/errRedirect'
export default {
  namespace: 'user',

  state: {
    data: {
      list: [],
      pagination: {},
    },
    loading: false,
    currentUser: {},
  },

  effects: {
    *fetch(_, { call, put }) {
      yield put({
        type: 'changeLoading',
        payload: true,
      });
      const response = yield call(queryUsers);
      yield put({
        type: 'save',
        payload: response,
      });
      yield put({
        type: 'changeLoading',
        payload: false,
      });
    },
    *fetchCurrent(_, { call, put }) {
      const response = yield call(queryCurrent);
      yield put({
        type: 'saveCurrentUser',
        payload: response,
      });
    },
    *index(_, { call, put }) {
      const response = yield call(index);
      //是否正确返回数据.根据错误code 跳转页面
      yield call(checkResponse, { response, put });
      yield put({
        type: 'loadList',
        payload: response.Value,
      })
    },
    *search(payload, { call, put }) {
      const response = yield call(search, payload);

      //是否正确返回数据.根据错误code 跳转页面
      yield call(checkResponse, { response, put });
      yield put({
        type: 'loadList',
        payload: response,
      })
    }
  },

  reducers: {
    save(state, action) {
      return {
        ...state,
        list: action.payload,
      };
    },
    changeLoading(state, action) {
      return {
        ...state,
        loading: action.payload,
      };
    },
    saveCurrentUser(state, action) {
      return {
        ...state,
        currentUser: action.payload,
      };
    },
    changeNotifyCount(state, action) {
      return {
        ...state,
        currentUser: {
          ...state.currentUser,
          notifyCount: action.payload,
        },
      };
    },
    loadList(state, { payload }) {
      console.log( payload.Value)
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
    },
  },
};
