import React, { PureComponent } from 'react';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
const FormItem = Form.Item;

export default class UserModal extends PureComponent {
    state = {
        data: {},
    };
    isok = () => {
        console.log(this.state.userName)
    }
    handleModalVisible = (flag) => {
        this.setState({
            modalVisible: true,
        })
    }
    changeInput = (e) => {
        this.setState({
            userName: e.target.value,
        })
    }
    render() {
        const { onCancel, modalVisible } = this.props;
        return (
            <Modal
                title="用户"
                visible={modalVisible}
                onOk={this.isok}
                onCancel={onCancel}
            >
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="手机号"
                >
                    <Input placeholder='6-12个字符' onChange={this.changeInput} value={this.state.userName}></Input>
                </FormItem>
            </Modal>
        )
    }
}