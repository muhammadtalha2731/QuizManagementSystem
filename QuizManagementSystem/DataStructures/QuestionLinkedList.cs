using System;
using System.Collections.Generic;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.DataStructures
{
    /// <summary>
    /// Custom Doubly Linked List implementation for managing quiz questions.
    /// Supports forward/backward navigation and full CRUD on the in-memory list.
    /// </summary>
    public class QuestionLinkedList
    {
        // ── Internal state ────────────────────────────
        private QuestionNode _head;
        private QuestionNode _tail;
        private QuestionNode _current;
        private int          _count;

        // ── Public properties ─────────────────────────
        public int          Count       => _count;
        public QuestionNode CurrentNode => _current;
        public bool         HasNext     => _current != null && _current.Next != null;
        public bool         HasPrevious => _current != null && _current.Previous != null;

        public QuestionLinkedList()
        {
            _head = _tail = _current = null;
            _count = 0;
        }

        // ── Core Operations ───────────────────────────

        /// <summary>Inserts a new question node at the end of the list.</summary>
        public void AddQuestion(QuestionNode node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            node.Next = null;
            node.Previous = null;

            if (_head == null)
            {
                _head = _tail = _current = node;
            }
            else
            {
                node.Previous = _tail;
                _tail.Next    = node;
                _tail         = node;
            }
            _count++;
        }

        /// <summary>Removes the node with the given questionId. Returns true if found and removed.</summary>
        public bool DeleteQuestion(int questionId)
        {
            QuestionNode node = FindById(questionId);
            if (node == null) return false;

            // Re-link neighbours
            if (node.Previous != null) node.Previous.Next = node.Next;
            else                        _head = node.Next;

            if (node.Next != null) node.Next.Previous = node.Previous;
            else                    _tail = node.Previous;

            // Move current pointer if it was on the deleted node
            if (_current == node)
                _current = node.Next ?? node.Previous;

            _count--;
            return true;
        }

        /// <summary>Navigates forward; returns the new current node (or the same if already at tail).</summary>
        public QuestionNode GetNext()
        {
            if (_current?.Next != null)
                _current = _current.Next;
            return _current;
        }

        /// <summary>Navigates backward; returns the new current node (or the same if already at head).</summary>
        public QuestionNode GetPrevious()
        {
            if (_current?.Previous != null)
                _current = _current.Previous;
            return _current;
        }

        /// <summary>Returns all nodes as a flat list (head → tail order).</summary>
        public List<QuestionNode> GetAllQuestions()
        {
            var list = new List<QuestionNode>();
            QuestionNode temp = _head;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.Next;
            }
            return list;
        }

        /// <summary>Updates the data of an existing node in-place. Returns false if not found.</summary>
        public bool UpdateQuestion(QuestionNode updated)
        {
            QuestionNode existing = FindById(updated.QuestionId);
            if (existing == null) return false;

            existing.QuestionText  = updated.QuestionText;
            existing.OptionA       = updated.OptionA;
            existing.OptionB       = updated.OptionB;
            existing.OptionC       = updated.OptionC;
            existing.OptionD       = updated.OptionD;
            existing.CorrectAnswer = updated.CorrectAnswer;
            existing.Subject       = updated.Subject;
            existing.Marks         = updated.Marks;
            return true;
        }

        /// <summary>Loads the list from a collection of Question model objects (clears existing data).</summary>
        public void LoadFromList(List<Question> questions)
        {
            _head = _tail = _current = null;
            _count = 0;

            foreach (var q in questions)
                AddQuestion(new QuestionNode(
                    q.QuestionId, q.QuestionText,
                    q.OptionA, q.OptionB, q.OptionC, q.OptionD,
                    q.CorrectAnswer, q.Subject, q.Marks));
        }

        /// <summary>Resets the current pointer back to the head.</summary>
        public void ResetToHead() => _current = _head;

        /// <summary>Returns the 1-based position of the current node.</summary>
        public int GetCurrentIndex()
        {
            int index = 1;
            QuestionNode temp = _head;
            while (temp != null)
            {
                if (temp == _current) return index;
                temp = temp.Next;
                index++;
            }
            return 0;
        }

        // ── Private helpers ───────────────────────────

        private QuestionNode FindById(int id)
        {
            QuestionNode temp = _head;
            while (temp != null)
            {
                if (temp.QuestionId == id) return temp;
                temp = temp.Next;
            }
            return null;
        }
    }
}
