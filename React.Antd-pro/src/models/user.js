import { query as queryUsers, queryCurrent, userSearch, resetPassword, add, update, changeDelflag, index } from '../services/user';
import { checkResponse, messagePut } from '../utils/errPut'
export default {
  namespace: 'user',

  state: {
    data: {
      list: [],
      pagination: {},
    },
    loading: false,
    currentUser: {},
    modal: {
      title: "",
      data: {},
      isAdd: true,
      confirmLoading: false,
      modalVisible: false
    }
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
    *userSearch({ payload }, { call, put }) {
      const response = yield call(userSearch, payload);
      yield put({
        type: 'loadList',
        payload: response.Value,
      })
    },
    *hideVisible(_, { call, put }) {
      yield put({
        type: 'hideModal',
      })
    },
    *changeModalVisible({ payload }, { call, put }) {
      yield put({
        type: 'changeVisible',
        payload: payload
      })
    },
    *updateAdmin({ payload }, { call, put }) {
      //加载
      yield put({ type: 'submitload' });
      const response = yield call(update, payload);
      //加载结束
      yield put({ type: 'submitload' });
      //提示信息
      yield call(messagePut, { response, put });
      if (response.Success) {
        //隐藏模态框
        yield put({ type: 'hideModal' });
        //table 加载
        yield put({
          type: 'changeLoading',
          payload: true,
        })
        //请求数据
        const rp = yield call(index);
        yield put({
          type: 'loadList',
          payload: rp.Value,
        })
        //加载结束
        yield put({
          type: 'changeLoading',
          payload: false,
        })
      }
    },
    *add({ payload }, { call, put }) {
      //加载
      yield put({ type: 'submitload' });
      const response = yield call(add, payload);
      //加载结束
      yield put({ type: 'submitload' });
      //提示信息
      yield call(messagePut, { response, put });
      if (response.Success) {
        //隐藏模态框
        yield put({ type: 'hideModal' });
        //table 加载
        yield put({
          type: 'changeLoading',
          payload: true,
        })
        //请求数据
        const rp = yield call(index);
        yield put({
          type: 'loadList',
          payload: rp.Value,
        })
        //加载结束
        yield put({
          type: 'changeLoading',
          payload: false,
        })
      }
    },
    *changeDelflag({ payload }, { call, put }) {
      const { record, formValues } = payload;
      const response = yield call(changeDelflag, record);
      yield call(messagePut, { response, put });
      yield put({
        type: 'changeLoading',
        payload: true,
      })
      const response1 = yield call(userSearch, {
        ...formValues,
        pagination: {}
      });
      yield put({
        type: 'loadList',
        payload: response1.Value,
      })
      yield put({
        type: 'changeLoading',
        payload: false,
      })
    },
    *resetPassword({ payload }, { call, put }) {
      const response = yield call(resetPassword, payload);
      yield call(messagePut, { response, put });
    },
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
    hideModal(state, action) {
      return {
        ...state,
        modal: {
          ...state.modal,
          modalVisible: false,
        },

      }
    },
    changeVisible(state, { payload }) {
      return {
        ...state,
        modal: {
          title: payload.title,
          data: payload.data,
          isAdd: payload.isAdd,
          modalVisible: true,
        }
      }
    },
    updateAdmin(state, { payload }) {
      return {
        ...state,
        modal: {
          data: payload,
        }
      }
    },
    submitload(state, { payload }) {
      return {
        ...state,
        modal: {
          ...state.modal,
          confirmLoading: !state.modal.confirmLoading
        }

      }
    },
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
    },
  },
};
