import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
const FormItem = Form.Item;
@connect(state => ({
    user: state.user,
}))
export default class OrdinaryUserModal extends PureComponent {
    state = {
        data: this.props.user.modal.data
    };
    isOk = () => {
        console.log(this.props.user);
    }
    changeInput = (e) => {
        const { data: { NickName, PhoneNum } } = this.state;
        const { value } = e.target;
        const { dispatch, form } = this.props;
        console.log(this.props)
        // form.validateFields((err, fieldsValue) => {
        //     console.log(fieldsValue)
        //     if (err) return;
        //     dispatch({
        //         type: 'updateModalData',
        //         data: fieldsValue,
        //     })
        // });


    }
    render() {
        const { onCancel } = this.props;
        const { modal: { title, data }, modalVisible } = this.props.user;
        console.log(this.props.user)
        return (
            <Modal
                title={title}
                visible={modalVisible}
                onOk={this.isOk}
                onCancel={onCancel}
                destroyOnClose={true}
            >
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="手机号"
                >
                    <Input placeholder='6-12个字符' name='PhoneNum' onChange={this.changeInput} value={data.PhoneNum}></Input>
                </FormItem>
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="昵 称"
                >
                    <Input placeholder='6-12个字符' name='NickName' onChange={this.changeInput} value={data.NickName}></Input>
                </FormItem>
            </Modal>
        )
    }
}