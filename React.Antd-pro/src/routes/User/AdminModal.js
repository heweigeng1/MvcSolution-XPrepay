import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
const FormItem = Form.Item;
@connect(state => ({
    user: state.user,
}))
@Form.create()
export default class AdminModal extends PureComponent {
    state = {

    };
    isOk = () => {
        const { data: { NickName, PhoneNum }, isAdd } = this.props.user.modal;
        const { dispatch, form } = this.props;
        form.validateFields((err, fieldsValue) => {
            const payload = {
                ...fieldsValue,
                Id: fieldsValue.key
            }
            if (err) return;
            if (isAdd) {
                dispatch({
                    type: 'user/add',
                    payload: fieldsValue
                })
            } else {
                dispatch({
                    type: 'user/updateAdmin',
                    payload: payload
                })
            }
        });
    }
    initFormItem = (isAdd, form, data) => {
        if (!isAdd) {
            return (
                form.getFieldDecorator('key', {
                    initialValue: data.key,
                })
                    (<input type="hidden"></input>)

            )
        }
    }
    render() {
        const { onCancel, form } = this.props;
        const { modal: { title, data, isAdd, modalVisible, confirmLoading } } = this.props.user;

        return (
            <Modal
                title={title}
                visible={modalVisible}
                confirmLoading={confirmLoading}
                onOk={this.isOk}
                onCancel={onCancel}
                destroyOnClose={true}
            >
                {this.initFormItem(isAdd, form, data)}
                {form.getFieldDecorator('UserType', {
                    initialValue: 1,//1为管理员,0普通用户
                })
                    (<input type="hidden"></input>)
                }
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="帐 号" >
                    {form.getFieldDecorator('UserName', {
                        initialValue: data.UserName,
                        rules: [{ required: true, message: '请输入帐号' },
                        { min: 5, message: '请输入5-12个字符' },
                        { max: 12, message: '请输入5-12个字符' },
                        ],
                    })
                        (<Input placeholder='请输入5-12个字符' disabled={!isAdd} ></Input>)
                    }
                </FormItem>
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="手 机" >
                    {form.getFieldDecorator('PhoneNum', {
                        initialValue: data.PhoneNum,
                        rules: [{ required: true, message: '请输入手机号' },
                        { pattern: /^[\d]{11}$/, message: '请输入11位手机号' }
                        ],
                    })
                        (<Input placeholder='请输入手机号'  ></Input>)}
                </FormItem>
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="昵 称" >
                    {form.getFieldDecorator('NickName', {
                        initialValue: data.NickName,
                    })
                        (<Input placeholder='6-12个字符' ></Input>)
                    }
                </FormItem>
            </Modal>
        )
    }
}